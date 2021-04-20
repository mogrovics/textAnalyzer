using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace WebTextAnalyzer.Models
{
    /**
     * number of char                                           x
     * number of char without whitespace                        x
     * number of char without digits                            x
     * number of digit
     * number of words                                          x
     * number of sentences                                      x
     * longest words                                            x
     * shortest word                                            x
     * most commons word and their number ocurencies            x
     * number of different word                                 x    
     * average number of character per word                             
     * number of syllable                                       x
     * number of syllable per word                              
     */
    public class Form
    {
        [DataType(DataType.MultilineText)]
        public string Input { get; set; }
        public int NumberOfChar { get; set; }
        public int NumberOfCharWithoutWhiteSpace { get; set; }
        public int NumberOfCharWithoutSpaceAndDigit { get; set; }
        public int NumberOfWords { get; set; }
        public int NumberOfSentences { get; set; }
        public List<string> ListOfLongestWords { get; set; }
        public List<string> ListOfShortestWords { get; set; }
        public Dictionary<string, int> MostCommonWords { get; set; }
        public int NumberOfDifferentWords { get; set; }
        public int NumberOfSyllables { get; set; }

        //TODO remove attribut only for testing 
        public List<string> Result { get; set; }


        public Form()
        {
            Result = new List<string>();
            ListOfLongestWords = new List<string>();
            ListOfShortestWords = new List<string>();
        }

        public void ComputeStats()
        {
            TextOperation textOperations = new TextOperation(Input);
            NumberOfChar = textOperations.CountCharacters();
            NumberOfCharWithoutWhiteSpace = textOperations.CountCharWithoutSpace();
            NumberOfCharWithoutSpaceAndDigit = textOperations.CountCharWithoutSpaceAndDigit();
            NumberOfWords = textOperations.CountWords();
            NumberOfSentences = textOperations.CountSentences();
            ListOfLongestWords = textOperations.ListOfLongestWords();
            ListOfShortestWords = textOperations.ListOfShortestWords();
            NumberOfSyllables = textOperations.CountSyllable();

            // next two items must be in this order otherwise NumberOfDifferntWords be 0
            MostCommonWords = textOperations.MostCommonWords();
            NumberOfDifferentWords = textOperations.NumberOfDifferentWords();
            //TODO remove attribut only for testing 
            Result.Add("Word count: " + NumberOfWords);
            Result.Add("Total character count: " + NumberOfChar);
            Result.Add("Character count (spaces not included): " + NumberOfCharWithoutWhiteSpace);
            Result.Add("Character count (spaces and digits not included): " + NumberOfCharWithoutSpaceAndDigit);
            Result.Add("Sentence count: " + NumberOfSentences);
            Result.Add("Syllable count: " + NumberOfSyllables);




        }

    }

}