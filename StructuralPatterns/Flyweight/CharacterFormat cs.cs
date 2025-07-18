using System.Collections.Concurrent;

namespace StructuralPatterns.Flyweight
{
    // Flyweight Interface
    public interface ICharacterFormat
    {
        void Display(char character); // Extrinsic state (character) is passed here
    }

    // Concrete Flyweight
    public class CharacterFormat : ICharacterFormat
    {
        private readonly string _fontName; // Intrinsic state (shared)
        private readonly int _fontSize;    // Intrinsic state (shared)
        private readonly bool _isBold;     // Intrinsic state (shared)
        private readonly bool _isItalic;   // Intrinsic state (shared)

        public CharacterFormat(string fontName, int fontSize, bool isBold, bool isItalic)
        {
            _fontName = fontName;
            _fontSize = fontSize;
            _isBold = isBold;
            _isItalic = isItalic;
        }

        public void Display(char character)
        {
            Console.WriteLine($"Character '{character}' with font: {_fontName}, size: {_fontSize}, " +
                              $"bold: {_isBold}, italic: {_isItalic}");
        }
    }

    // Flyweight Factory
    public class FormatFactory
    {
        private static readonly ConcurrentDictionary<string, ICharacterFormat> _formats = new();

        public static ICharacterFormat GetFormat(string fontName, int fontSize, bool isBold, bool isItalic)
        {
            string key = $"{fontName}_{fontSize}_{isBold}_{isItalic}";
            return _formats.GetOrAdd(key, new CharacterFormat(fontName, fontSize, isBold, isItalic));
        }
    }

    // Client: Represents a character in the document
    public class DocumentCharacter
    {
        private readonly char _character; // Extrinsic state
        private readonly ICharacterFormat _format; // Flyweight reference

        public DocumentCharacter(char character, ICharacterFormat format)
        {
            _character = character;
            _format = format;
        }

        public void Display()
        {
            _format.Display(_character);
        }
    }
}
