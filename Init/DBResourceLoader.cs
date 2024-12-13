using ccex_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using ccex_api.Aggregates;

namespace ccex_api.Init;

public static class DBResourceLoader
{

  private static DbContext _context = null!;
  private readonly static string characterDataFile = "./DataFiles/ChineseCharacterData.json";
  private readonly static string pinyinDataFile = "./DataFiles/PinyinData.json";

  public static void LoadInitialCharData(DbContext context)
  {
    _context = context;
    int batchsize = 100;

    List<ChineseCharacterInit> characterData = LoadCharacterData();
    ContextDelegate<ChineseCharacterInit> AddCharactersDelegate = AddCharacters;

    Console.WriteLine("Adding characters to the database");
    for (int i = 0; i < characterData.Count; i++)
    {
      BatchOperation(AddCharactersDelegate, characterData[i], i, batchsize);
    }
    _context.SaveChanges();
    

    List<PinyinInit> pinyinData = LoadPinyinData();
    ContextDelegate<PinyinInit> AddPinyinDelegate = AddPinyin;

    Console.WriteLine("Adding pinyin to the database");
    for (int i = 0; i < pinyinData.Count; i++)
    {
      BatchOperation(AddPinyinDelegate, pinyinData[i], i, batchsize);
    }
    _context.SaveChanges();


    ContextDelegate<ChineseCharacterInit> PopulateCharactersDelegate = PopulateCharacters;

    Console.WriteLine("Populating character fields");
    for (int i = 0; i < characterData.Count; i++)
    {
      BatchOperation(PopulateCharactersDelegate, characterData[i], i, batchsize);
    }
    _context.SaveChanges();


    // ContextDelegate<ChineseCharacterInit> PopulateCharactersDelegate = PopulateCharacters;

    // for (int i = 0; i < characterData.Count;
    // {
    //   BatchOperation(PopulateCharactersDelegate, characterData[i], i, batchsize);
    // }
    // _context.SaveChanges();


  }

  private static void BatchOperation<T>(ContextDelegate<T> fn, T entity, int count, int batchsize)
  {
    fn(entity);
    if ((count + 1) % batchsize == 0) _context.SaveChanges();
  }

  private delegate void ContextDelegate<T>(T entity);


  private static void PopulatePinyin(PinyinInit pinyin)
  {
    Pinyin? py = _context.Set<Pinyin>().FirstOrDefault(x => x.SyllableWithToneMark == pinyin.syllableWithToneMark) ??
      throw new Exception($"Pinyin not found: {pinyin.syllableWithToneMark}");

    // _context.Set<Pinyin>().SelectMany(x =>)
  }

  private static void PopulateCharacters(ChineseCharacterInit cchar)
  {

    ChineseCharacter? character = _context.Set<ChineseCharacter>().FirstOrDefault(x => x.Char == cchar.Char) ??
      throw new Exception($"Character not found: {cchar.Char}");

    foreach (string c in cchar.Components)
    {
      ChineseCharacter? component = _context.Set<ChineseCharacter>().FirstOrDefault(x => x.Char == c) ??
        throw new Exception($"Component not found: {c}");

      character.Components.Add(component);
    }

    foreach (string c in cchar.Derivatives)
    {
      ChineseCharacter? component = _context.Set<ChineseCharacter>().FirstOrDefault(x => x.Char == c) ??
        throw new Exception($"Derivative not found: {c}");

      character.Derivatives.Add(component);
    }

    foreach (string c in cchar.Variants)
    {
      ChineseCharacter? component = _context.Set<ChineseCharacter>().FirstOrDefault(x => x.Char == c) ??
        throw new Exception($"Variant not found: {c}");

      character.Variants.Add(component);
    }

    if (cchar.Base != null)
    {
      ChineseCharacter? component = _context.Set<ChineseCharacter>().FirstOrDefault(x => x.Char == cchar.Base) ??
        throw new Exception($"Base not found: {cchar.Base}");

      character.Base = component;
    }

  }

  private static void AddCharacters(ChineseCharacterInit cchar)
  {
    var TradChars = cchar.TradChars.Select(c => new TradCharacterStub {
          Char = c.Char,
          Definition = c.Definition,
          Description = c.Description,
          Pinyin = c.Pinyin
        }).ToList();

    _context.Set<ChineseCharacter>().Add(
      new ChineseCharacter {
        Char = cchar.Char,
        TradChars = TradChars,
        PrimaryPinyin = cchar.PrimaryPinyin,
        SecondaryPinyin = cchar.SecondaryPinyin,
        Definition = cchar.Definition,
        Description = cchar.Description,
        Frequency = cchar.Frequency
      }
    );
  }

  private static void AddPinyin(PinyinInit py)
  {
    _context.Set<Pinyin>().Add(
      new Pinyin {
        Syllable = py.syllable,
        ToneNumber = py.toneNumber,
        SyllableWithToneMark = py.syllableWithToneMark
      }
    );
  }

  private static List<ChineseCharacterInit> LoadCharacterData()
  {
    using StreamReader reader = new StreamReader(characterDataFile);

    var objects = JsonConvert.DeserializeObject<List<ChineseCharacterInit>>(reader.ReadToEnd()) ??
      throw new Exception("JSON parsing problem");

    return objects;
  }

  private static List<PinyinInit> LoadPinyinData()
  {
    using StreamReader reader = new StreamReader(pinyinDataFile);

    var objects = JsonConvert.DeserializeObject<List<PinyinInit>>(reader.ReadToEnd()) ??
      throw new Exception("JSON parsing problem");

    return objects;
  }

}