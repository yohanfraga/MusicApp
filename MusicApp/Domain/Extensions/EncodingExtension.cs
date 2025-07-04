using System.Linq;
using System.Text;

namespace MusicApp.Domain.Extensions
{
    public static class EncodingExtension
    {
        public static string GetAllWritableCharacters(Encoding encoding)
        {
            return new string(
                Enumerable.Range(0, char.MaxValue + 1)
                    .Select(i => (char)i)
                    .Where(c => !char.IsControl(c))
                    .ToArray());
        }
    }
} 