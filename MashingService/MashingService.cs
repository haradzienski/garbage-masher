using System;
using System.Text;
using System.Collections.Generic;

namespace MashingService
{
    public class MashingService
    {
        public string Mash(string input) {
            var freqMap = BuildFreqMap(input);
            var outputBuilder = new StringBuilder(input.Length);

            foreach (KeyValuePair<char, int> entry in freqMap) {
                if (entry.Value > 1) {
                    outputBuilder.AppendFormat("{0}{1}", entry.Key, entry.Value);
                } else {
                    outputBuilder.Append(entry.Key);
                }
            }

            return outputBuilder.ToString();
        }

        private Dictionary<char, int> BuildFreqMap(string input) {
            var dictionary = new Dictionary<char, int>();
            foreach (var symbol in input)
            {
                if (!dictionary.ContainsKey(symbol)) {
                    dictionary.Add(symbol, 0);
                }

                dictionary[symbol]++;
            }

            return dictionary;
        }
    }
}
