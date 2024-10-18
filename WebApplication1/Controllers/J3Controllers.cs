using Microsoft.AspNetCore.Mvc;

namespace J3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
    
        [HttpPost("Translate")]
        public IActionResult TranslateToRobbersLanguage([FromForm] string word)
        {
            if (string.IsNullOrWhiteSpace(word) || word.Length > 30)
            {
                return BadRequest("Input must be a non-empty word with at most 30 letters.");
            }

            string translatedWord = Translate(word);
            return Ok(translatedWord);
        }

        private string Translate(string word)
        {
            string vowels = "aeiou";
            string result = "";

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                // Check the character is a consonant
                if (!vowels.Contains(currentChar))
                {
                    // Find closest vowel
                    char closestVowel = FindClosestVowel(currentChar);
                    // Find next consonant
                    char nextConsonant = FindNextConsonant(currentChar);

            
                    result += $"{currentChar}{closestVowel}{nextConsonant}";
                }
                else
                {
                    // If it's a vowel, just add it to the result
                    result += currentChar;
                }
            }

            return result;
        }

        private char FindClosestVowel(char consonant)
        {
            // Define vowel positions
            string vowels = "aeiou";
            int closestIndex = 0;
            int minDistance = int.MaxValue;

            for (int i = 0; i < vowels.Length; i++)
            {
                int distance = Math.Abs(consonant - vowels[i]);
                if (distance < minDistance || 
                    (distance == minDistance && vowels[i] < vowels[closestIndex]))
                {
                    minDistance = distance;
                    closestIndex = i;
                }
            }

            return vowels[closestIndex];
        }

        private char FindNextConsonant(char consonant)
        {
            // Increment to the next consonant
            char nextChar = (char)(consonant + 1);
            while (nextChar <= 'z')
            {
                if ("aeiou".IndexOf(nextChar) == -1) // Check if it's not a vowel
                {
                    return nextChar;
                }
                nextChar++;
            }
            return consonant; // Return the consonant itself if it's 'z'
        }
    }
}
