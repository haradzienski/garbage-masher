using System;
using System.Text;
using System.Collections.Generic;

namespace MashingService
{


    public class MashingService
    {
        public string Mash(string input) {
            if (String.IsNullOrEmpty(input)) {
                return String.Empty;
            }

            var symbolRanges = CountConsecutiveOccurrences(input);
            var outputBuilder = new StringBuilder(input.Length);

            foreach ((char Symbol, int Count) entry in symbolRanges) {
                var shouldEscapeSymbol = IsDigit(entry.Symbol);
                if (entry.Count > 2) {
                    outputBuilder.AppendFormat(
                        "{0}{1}{2}",
                        shouldEscapeSymbol ? "\\" : String.Empty,
                        entry.Symbol,
                        entry.Count);
                } else {
                    if (shouldEscapeSymbol) {
                        for (var i = 0; i < entry.Count; i++) {
                            outputBuilder.AppendFormat("\\{0}", entry.Symbol);
                        }
                    } else {
                        outputBuilder.Append(entry.Symbol, entry.Count);
                    }
                }
            }

            return outputBuilder.ToString();
        }

        private List<(char Symbol, int Count)> CountConsecutiveOccurrences(string input) {
            var list = new List<(char Symbol, int Count)>();
            (char Symbol, int Count) currentEntry = (input[0], 0);
            foreach (var symbol in input) {
                if (symbol != currentEntry.Symbol) {
                    list.Add(currentEntry);
                    currentEntry = (symbol, 0);
                }

                currentEntry.Count++;
            }

            list.Add(currentEntry);

            return list;
        }

        private bool IsDigit(char symbol) {
            return symbol > '0' && symbol < '9';
        }
    }
}
