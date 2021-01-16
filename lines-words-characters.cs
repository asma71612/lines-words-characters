using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
            // These characters are trimmed from words.

            char[ ] punctuationChars = ".?!,;:-'\"()".ToCharArray( );

            // The 'HashSet< T >' type stores added values only if they are unique.

            HashSet< char > charSet = new HashSet< char >( );
            HashSet< string > wordSet = new HashSet< string >( );

            // TO DO: Complete this method to count line/word/character information.
            
            // data needed to open the file 
            const string path = "Hofstadter.txt";
            const FileMode mode = FileMode.Open;
            const FileAccess access = FileAccess.Read;
            
            // makes sure that the file is closed when clock is done running 
            using FileStream file = new FileStream ( path, mode, access );
            // create a StreamReader to view file as lines of text and count number of lines and characters in file
            using StreamReader reader = new StreamReader ( file );
            
            // skips the first 5 lines
            for ( int i = 0; i < 4; i++ ) reader.ReadLine ( );
            
            int lineCount = 0;
            int wordCount = 0;
            int uniqueWordCount = 0;
            int thisCount = 0;
            int characterCount = 0;
            int notWhiteCount = 0;
            int letterCount = 0;
            int punctuationCount = 0;
            int digitCount = 0;
            int uniqueCharacterCount = 0;
            int tCount = 0;
            
            // reading in the stuff 
            while ( !reader.EndOfStream )
            {
                string line = reader.ReadLine ( );
                line = line.ToLower ( );
                
                lineCount++;
                
                string [ ] words = line.Split ( );
                foreach ( string s in words )
                {
                    string word = s.Trim ( punctuationChars );
                    if ( word.Length > 3 )
                    {
                        wordCount++;
                        wordSet.Add ( word );
                        if ( word == "this" ) thisCount++;
                    }
                }
                
                characterCount += line.Length;
                foreach ( char c in line )
                {
                    charSet.Add ( c );
                    if ( !char.IsWhiteSpace ( c ) ) notWhiteCount++;
                    if ( char.IsLetter ( c ) ) letterCount ++;
                    if ( char.IsPunctuation ( c ) ) punctuationCount ++;
                    if ( char.IsDigit ( c ) ) digitCount ++;
                    if ( c == 't' ) tCount ++;
                }
            }

            // Display the line/word/character counts.
            string fmt = "{0,17} : {1:n0}";
            WriteLine( );
            WriteLine( fmt, "Item", "Count" );
            WriteLine( );
            WriteLine( fmt, "line", lineCount );
            WriteLine( );
            WriteLine( fmt, "word", wordCount );
            WriteLine( fmt, "unique word", wordSet.Count );
            WriteLine( fmt, "\"this\"", thisCount );
            WriteLine( );
            WriteLine( fmt, "character", characterCount );
            WriteLine( fmt, "not white space", notWhiteCount );
            WriteLine( fmt, "letter", letterCount );
            WriteLine( fmt, "punctuation", punctuationCount );
            WriteLine( fmt, "digit", digitCount );
            WriteLine( fmt, "unique character", charSet.Count );
            WriteLine( fmt, "'t'", tCount );
            WriteLine( );
        }
    }
}
