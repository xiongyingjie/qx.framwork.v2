﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Qx.Tools
{
    /// <summary>
    ///     This class can generate random strings and supports following settings:
    ///     1) 4 character sets (UpperCase, LowerCase, Numeric and Special characters)
    ///     2) Variable number of the character sets in use
    ///     3) Minimal number of each type of the characters
    ///     4) Pattern driven string generation
    ///     5) Unique string generation
    ///     6) Using each character only once
    ///     It can be easily used for generation of a password or an identificator.
    /// </summary>
    public class RandomStringGenerator
    {
        /// <summary>
        ///     True if characters can be repeated.
        /// </summary>
        public bool RepeatCharacters;

        /// <summary>
        ///     True if it's not possible to create similar strings.
        /// </summary>
        public bool UniqueStrings;

        public RandomStringGenerator(bool UseUpperCaseCharacters = true,
            bool UseLowerCaseCharacters = true,
            bool UseNumericCharacters = true,
            bool UseSpecialCharacters = false)
        {
            m_UseUpperCaseCharacters = UseUpperCaseCharacters;
            m_UseLowerCaseCharacters = UseLowerCaseCharacters;
            m_UseNumericCharacters = UseNumericCharacters;
            m_UseSpecialCharacters = UseSpecialCharacters;
            CurrentGeneralCharacters = new char[0]; // avoiding null exceptions
            UpperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            LowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            NumericCharacters = "0123456789".ToCharArray();
            SpecialCharacters = ",.;:?!/@#$%^&()=+*-_{}[]<>|~".ToCharArray();
            MinUpperCaseCharacters = MinLowerCaseCharacters = MinNumericCharacters = MinSpecialCharacters = 0;
            RepeatCharacters = true;
            PatternDriven = false;
            Pattern = "";
            Random = new RNGCryptoServiceProvider();
            ExistingStrings = new List<string>();
        }

        /// <summary>
        ///     Adding the string to the history array to support unique string generation.
        /// </summary>
        public void AddExistingString(string s)
        {
            ExistingStrings.Add(s);
        }

        /// <summary>
        ///     A 16bit integer number generator.
        /// </summary>
        /// <returns>A random integer value from 0 to 65576</returns>
        private int GetRandomInt()
        {
            var buffer = new byte[2]; // 16 bit = 2^16 = 65576 (more than necessary)
            Random.GetNonZeroBytes(buffer);
            int index = BitConverter.ToInt16(buffer, 0);
            if (index < 0)
                index = -index; // manage negative random values
            return index;
        }

        #region length of the string

        /// <summary>
        ///     Value of the string's maximal length. Turns on the variable length mode.
        ///     Setting the variable length will disable fixed length by setting it to -1.
        /// </summary>
        private int MaxLength
        {
            get { return m_MaxLength; }
            set
            {
                m_MaxLength = value;
                if (m_MinLength > value)
                    m_MinLength = value;
                m_FixedLength = -1; // not using fixed length
            }
        }

        /// <summary>
        ///     Value of the string's minimal length. Turns on the variable length mode.
        ///     Setting the variable length will disable fixed length by setting it to -1.
        /// </summary>
        private int MinLength
        {
            get { return m_MinLength; }
            set
            {
                m_MinLength = value;
                if (m_MaxLength < value)
                    m_MaxLength = value;
                m_FixedLength = -1; // not using fixed length
            }
        }

        /// <summary>
        ///     Value of the string's fixed length. Turns on the fixed length mode.
        ///     Setting the fixed length will disable max and min length by setting them to -1.
        /// </summary>
        private int FixedLength
        {
            get { return m_FixedLength; }
            set
            {
                m_FixedLength = value;
                // not using max and min length
                m_MaxLength = -1;
                m_MinLength = -1;
            }
        }

        #endregion

        #region character sets managers

        /// <summary>
        ///     True if we need to use upper case characters
        /// </summary>
        public bool UseUpperCaseCharacters
        {
            get { return m_UseUpperCaseCharacters; }
            set
            {
                if (CurrentUpperCaseCharacters != null)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentUpperCaseCharacters).ToArray();
                if (value)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(CurrentUpperCaseCharacters).ToArray();
                m_UseUpperCaseCharacters = value;
            }
        }

        /// <summary>
        ///     Sets or gets upper case character set.
        /// </summary>
        public char[] UpperCaseCharacters
        {
            get { return CurrentUpperCaseCharacters; }
            set
            {
                if (UseUpperCaseCharacters)
                {
                    if (CurrentUpperCaseCharacters != null)
                        CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentUpperCaseCharacters).ToArray();
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(value).ToArray();
                }
                CurrentUpperCaseCharacters = value;
            }
        }

        /// <summary>
        ///     True if we need to use lower case characters
        /// </summary>
        public bool UseLowerCaseCharacters
        {
            get { return m_UseLowerCaseCharacters; }
            set
            {
                if (CurrentLowerCaseCharacters != null)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentLowerCaseCharacters).ToArray();
                if (value)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(CurrentLowerCaseCharacters).ToArray();
                m_UseLowerCaseCharacters = value;
            }
        }

        /// <summary>
        ///     Sets or gets lower case character set.
        /// </summary>
        public char[] LowerCaseCharacters
        {
            get { return CurrentLowerCaseCharacters; }
            set
            {
                if (UseLowerCaseCharacters)
                {
                    if (CurrentLowerCaseCharacters != null)
                        CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentLowerCaseCharacters).ToArray();
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(value).ToArray();
                }
                CurrentLowerCaseCharacters = value;
            }
        }

        /// <summary>
        ///     True if we need to use numeric characters
        /// </summary>
        public bool UseNumericCharacters
        {
            get { return m_UseNumericCharacters; }
            set
            {
                if (CurrentNumericCharacters != null)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentNumericCharacters).ToArray();
                if (value)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(CurrentNumericCharacters).ToArray();
                m_UseNumericCharacters = value;
            }
        }

        /// <summary>
        ///     Sets or gets numeric character set.
        /// </summary>
        public char[] NumericCharacters
        {
            get { return CurrentNumericCharacters; }
            set
            {
                if (UseNumericCharacters)
                {
                    if (CurrentNumericCharacters != null)
                        CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentNumericCharacters).ToArray();
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(value).ToArray();
                }
                CurrentNumericCharacters = value;
            }
        }

        /// <summary>
        ///     True if we need to use special characters
        /// </summary>
        public bool UseSpecialCharacters
        {
            get { return m_UseSpecialCharacters; }
            set
            {
                if (CurrentSpecialCharacters != null)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentSpecialCharacters).ToArray();
                if (value)
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(CurrentSpecialCharacters).ToArray();
                m_UseSpecialCharacters = value;
            }
        }

        /// <summary>
        ///     Sets or gets special character set.
        /// </summary>
        public char[] SpecialCharacters
        {
            get { return CurrentSpecialCharacters; }
            set
            {
                if (UseSpecialCharacters)
                {
                    if (CurrentSpecialCharacters != null)
                        CurrentGeneralCharacters = CurrentGeneralCharacters.Except(CurrentSpecialCharacters).ToArray();
                    CurrentGeneralCharacters = CurrentGeneralCharacters.Concat(value).ToArray();
                }
                CurrentSpecialCharacters = value;
            }
        }

        #endregion

        #region character limits

        /// <summary>
        ///     Sets or gets minimal number of the upper case characters in generated strings.
        /// </summary>
        public int MinUpperCaseCharacters { get; set; }

        /// <summary>
        ///     Sets or gets minimal number of the lower case characters in generated strings.
        /// </summary>
        public int MinLowerCaseCharacters { get; set; }

        /// <summary>
        ///     Sets or gets minimal number of the numeric characters in generated strings.
        /// </summary>
        public int MinNumericCharacters { get; set; }

        /// <summary>
        ///     Sets or gets minimal number of the special characters in generated strings.
        /// </summary>
        public int MinSpecialCharacters { get; set; }

        #endregion

        #region pattern

        private string m_pattern;

        /// <summary>
        ///     Defines the pattern to be followed to generate a string.
        ///     This value is ignored if it equals empty string.
        ///     Patterns are:
        ///     L - for upper case letter
        ///     l - for lower case letter
        ///     n - for number
        ///     s - for special character
        ///     * - for any character
        /// </summary>
        private string Pattern
        {
            get { return m_pattern; }
            set
            {
                if (!value.Equals(string.Empty))
                    PatternDriven = true;
                else
                    PatternDriven = false;
                m_pattern = value;
            }
        }

        #endregion

        #region generators

        /// <summary>
        ///     Generate a string which follows the pattern.
        ///     Possible characters are:
        ///     L - for upper case letter
        ///     l - for lower case letter
        ///     n - for number
        ///     s - for special character
        ///     * - for any character
        /// </summary>
        /// <param name="Pattern">The pattern to follow while generation</param>
        /// <returns>A random string which follows the pattern</returns>
        public string Generate(string Pattern)
        {
            this.Pattern = Pattern;
            var res = GenerateString(Pattern.Length);
            this.Pattern = "";
            return res;
        }

        /// <summary>
        ///     Generate a string of a variable length from MinLength to MaxLength. The possible
        ///     character sets should be defined before calling this function.
        /// </summary>
        /// <param name="MinLength">Minimal length of a string</param>
        /// <param name="MaxLength">Maximal length of a string</param>
        /// <returns>A random string from the selected range of length</returns>
        public string Generate(int MinLength, int MaxLength)
        {
            if (MaxLength < MinLength)
                throw new ArgumentException("Maximal length should be grater than minumal");
            this.MinLength = MinLength;
            this.MaxLength = MaxLength;
            var length = MinLength + GetRandomInt()%(MaxLength - MinLength);
            return GenerateString(length);
        }

        /// <summary>
        ///     Generate a string of a fixed length. The possible
        ///     character sets should be defined before calling this function.
        /// </summary>
        /// <param name="FixedLength">The length of a string</param>
        /// <returns>A random string of the desirable length</returns>
        public string Generate(int FixedLength)
        {
            this.FixedLength = FixedLength;
            return GenerateString(FixedLength);
        }

        /// <summary>
        ///     Main generation method which chooses the algorithm to use for the generation.
        /// </summary>
        private string GenerateString(int length)
        {
            if (length == 0)
                throw new ArgumentException("You can't generate a string of a zero length");
            if (!UseUpperCaseCharacters && !UseLowerCaseCharacters && !UseNumericCharacters && !UseSpecialCharacters)
                throw new ArgumentException("There should be at least one character set in use");
            if (!RepeatCharacters && (CurrentGeneralCharacters.Length < length))
                throw new ArgumentException("There is not enough characters to create a string without repeats");
            var result = ""; // This string will contain the result
            if (PatternDriven)
            {
                // Using the pattern to generate a string
                result = PatternDrivenAlgo(Pattern);
            }
            else if (MinUpperCaseCharacters == 0 && MinLowerCaseCharacters == 0 &&
                     MinNumericCharacters == 0 && MinSpecialCharacters == 0)
            {
                // Using the simpliest algorithm in this case
                result = SimpleGenerateAlgo(length);
            }
            else
            {
                // Paying attention to limits
                result = GenerateAlgoWithLimits(length);
            }
            // Support for unique strings
            if (UniqueStrings && ExistingStrings.Contains(result))
                return GenerateString(length);
            AddExistingString(result); // Saving history
            return result;
        }

        /// <summary>
        ///     Generate a random string following the pattern
        /// </summary>
        private string PatternDrivenAlgo(string Pattern)
        {
            var result = "";
            var Characters = new List<char>();
            foreach (var character in Pattern)
            {
                var newChar = ' ';
                switch (character)
                {
                    case 'L':
                    {
                        do
                        {
                            newChar = CurrentUpperCaseCharacters[GetRandomInt()%CurrentUpperCaseCharacters.Length];
                        } while (!RepeatCharacters && Characters.Contains(newChar));
                        break;
                    }
                    case 'l':
                    {
                        do
                        {
                            newChar = CurrentLowerCaseCharacters[GetRandomInt()%CurrentLowerCaseCharacters.Length];
                        } while (!RepeatCharacters && Characters.Contains(newChar));
                        break;
                    }
                    case 'n':
                    {
                        do
                        {
                            newChar = CurrentNumericCharacters[GetRandomInt()%CurrentNumericCharacters.Length];
                        } while (!RepeatCharacters && Characters.Contains(newChar));
                        break;
                    }
                    case 's':
                    {
                        do
                        {
                            newChar = CurrentSpecialCharacters[GetRandomInt()%CurrentSpecialCharacters.Length];
                        } while (!RepeatCharacters && Characters.Contains(newChar));
                        break;
                    }
                    case '*':
                    {
                        do
                        {
                            newChar = CurrentGeneralCharacters[GetRandomInt()%CurrentGeneralCharacters.Length];
                        } while (!RepeatCharacters && Characters.Contains(newChar));
                        break;
                    }
                    default:
                    {
                        throw new Exception("The character '" + character + "' is not supported");
                    }
                }
                Characters.Add(newChar);
                result += newChar;
            }
            return result;
        }

        /// <summary>
        ///     The simpliest algorithm of the random string generation. It doesn't pay attention to
        ///     limits and patterns.
        /// </summary>
        private string SimpleGenerateAlgo(int length)
        {
            var result = "";
            // No special limits
            for (var i = 0; i < length; i++)
            {
                var newChar = CurrentGeneralCharacters[GetRandomInt()%CurrentGeneralCharacters.Length];
                if (!RepeatCharacters && result.Contains(newChar))
                {
                    do
                    {
                        newChar = CurrentGeneralCharacters[GetRandomInt()%CurrentGeneralCharacters.Length];
                    } while (result.Contains(newChar));
                }
                result += newChar;
            }
            return result;
        }

        /// <summary>
        ///     Generate a random string with specified number of minimal characters of each character set.
        /// </summary>
        private string GenerateAlgoWithLimits(int length)
        {
            var result = "";
            if (MinUpperCaseCharacters + MinLowerCaseCharacters +
                MinNumericCharacters + MinSpecialCharacters > length)
            {
                throw new ArgumentException("Sum of MinUpperCaseCharacters, MinLowerCaseCharacters," +
                                            " MinNumericCharacters and MinSpecialCharacters is greater than length");
            }
            if (!RepeatCharacters && (MinUpperCaseCharacters > CurrentUpperCaseCharacters.Length))
                throw new ArgumentException("Can't generate a string with this number of MinUpperCaseCharacters");
            if (!RepeatCharacters && (MinLowerCaseCharacters > CurrentLowerCaseCharacters.Length))
                throw new ArgumentException("Can't generate a string with this number of MinLowerCaseCharacters");
            if (!RepeatCharacters && (MinNumericCharacters > CurrentNumericCharacters.Length))
                throw new ArgumentException("Can't generate a string with this number of MinNumericCharacters");
            if (!RepeatCharacters && (MinSpecialCharacters > CurrentSpecialCharacters.Length))
                throw new ArgumentException("Can't generate a string with this number of MinSpecialCharacters");
            var AllowedNumberOfGeneralChatacters = length - MinUpperCaseCharacters - MinLowerCaseCharacters
                                                   - MinNumericCharacters - MinSpecialCharacters;
            // generation character set
            var Characters = new List<char>();
            var Character = ' ';
            for (var i = 0; i < MinUpperCaseCharacters; i++)
            {
                do
                {
                    Character = UpperCaseCharacters[GetRandomInt()%UpperCaseCharacters.Length];
                } while (Characters.Contains(Character));
                Characters.Add(Character);
            }
            for (var i = 0; i < MinLowerCaseCharacters; i++)
            {
                do
                {
                    Character = LowerCaseCharacters[GetRandomInt()%LowerCaseCharacters.Length];
                } while (!RepeatCharacters && Characters.Contains(Character));
                Characters.Add(Character);
            }
            for (var i = 0; i < MinNumericCharacters; i++)
            {
                do
                {
                    Character = NumericCharacters[GetRandomInt()%NumericCharacters.Length];
                } while (!RepeatCharacters && Characters.Contains(Character));
                Characters.Add(Character);
            }
            for (var i = 0; i < MinSpecialCharacters; i++)
            {
                do
                {
                    Character = SpecialCharacters[GetRandomInt()%SpecialCharacters.Length];
                } while (!RepeatCharacters && Characters.Contains(Character));
                Characters.Add(Character);
            }
            for (var i = 0; i < AllowedNumberOfGeneralChatacters; i++)
            {
                do
                {
                    Character = CurrentGeneralCharacters[GetRandomInt()%CurrentGeneralCharacters.Length];
                } while (!RepeatCharacters && Characters.Contains(Character));
                Characters.Add(Character);
            }
            // generating result
            for (var i = 0; i < length; i++)
            {
                var position = GetRandomInt()%Characters.Count;
                var CurrentChar = Characters[position];
                Characters.RemoveAt(position);
                result += CurrentChar;
            }
            return result;
        }

        #endregion

        #region internal state

        private bool m_UseUpperCaseCharacters, m_UseLowerCaseCharacters, m_UseNumericCharacters, m_UseSpecialCharacters;
        private int m_MaxLength, m_MinLength, m_FixedLength;
        private bool PatternDriven;
        private char[] CurrentUpperCaseCharacters;
        private char[] CurrentLowerCaseCharacters;
        private char[] CurrentNumericCharacters;
        private char[] CurrentSpecialCharacters;
        private char[] CurrentGeneralCharacters; // All used characters
        private readonly RNGCryptoServiceProvider Random;
        private readonly List<string> ExistingStrings; // History

        #endregion
    }
}