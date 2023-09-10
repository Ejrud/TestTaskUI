using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpriteLibrary", fileName = "SpriteLibrary")]
public class SpriteLibrary : ScriptableObject
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private List<SpriteData> _spriteDatas;
    private Dictionary<string, Sprite> _imageLibrary;

    public void Init()
    {
        _imageLibrary = new Dictionary<string, Sprite>();
        foreach (var data in _spriteDatas)
        {
            _imageLibrary.Add(data.Name, data.Sprite);
        }
    }

    public Sprite GetSpriteByName(string spriteName)
    {
        if (_imageLibrary.TryGetValue(spriteName, out Sprite sprite))
        {
            return sprite;
        }
        
        return _defaultSprite;
    }
}
