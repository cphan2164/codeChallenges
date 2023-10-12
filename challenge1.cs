using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace code_challenges;

public class challenge1
{

    public static void Main(string[] args){
        challenge1 tester = new challenge1();
        // This is used to test each function individually
        tester.revSentence();
    }

    // This function finds the longest unique substring in a line
    public void uniqueChars(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        List<char> chars = new List<char>();
        int longest = 0;
        int flag = 0;
        string current = "";
        string longUni = "";
        // Loops through each character so each character is the starting character at some point
        for(int i = 0; i < line.Length; i++){
            // Loops through all substrings of each character
            for(int j = 1; j <= line.Length-i;j++){
                // If j is smaller then the longest substring at the moment then that substring can't be the longest so we can skip it
                if(j > longest){
                    current = line.Substring(i,j);
                    // Go through substring and check to see if every character is unique
                    for(int k = 0; k < current.Length; k++){
                        if(!chars.Contains(current[k])){ 
                            chars.Add(current[k]); //Adds character to list if its first time seen
                        }
                        else{
                            flag = 1; // If not unique flags program and breaks for loop
                            break;
                        }
                    }
                    if(flag == 1){
                        flag = 0; // If flagged then its not unique, flag goes back to 0 and next substring is looked at
                    }
                    else{
                        longest = j; // If not flagged, then its new longest. String and int updated accordingly
                        longUni = current;
                    }
                    chars.Clear(); //Clears list so each character will again be unique
                        
                }
            }
        }
        Console.WriteLine("The Longest unique substring is: ");
        Console.WriteLine(longUni);
        Console.WriteLine("With " + longest + " characters.");
    }

    // This function finds all substrings of a string
    public void allSubs(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        Console.WriteLine("Here is all substrings for the line");
        // Loops through each character so each character is the starting character at some point
        for(int i = 0; i < line.Length; i++){
            for(int j = 1; j <= line.Length - i; j++){  // Loops through all substrings of each character
                Console.Write(line.Substring(i,j) + " ");
            }

        }
    }

    // This function removes all duplicate characters excluding spaces from a line
    public void remDupes(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        string noDupes = "";
        List<char> chars = new List<char>(); //Character array keeping track of used characters
        for(int i = 0; i < line.Length; i++){
            if(!chars.Contains(line[i]) && line[i] != ' '){
                noDupes += line[i]; //If its a unique character its added to the string
                chars.Add(line[i]); // Character is then added to character list, and is no longer unique
            }
            else if(line[i] == ' '){
                noDupes+=line[i];
            }
        }

        Console.WriteLine("Here's your string without duplicates");
        Console.WriteLine(noDupes);

    }

    // This function counts the usuage of each character in a line, excluding spaces
    public void charCounter(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        Dictionary<char, int> charNum = new Dictionary<char, int>(); //Create a dictionary with characters and appearances
        for(int i = 0; i < line.Length; i++){
            if(line[i] == ' '){
                continue;
            }
            else if(!charNum.ContainsKey(line[i])){
                charNum.Add(line[i],1); // First appearance of a character
            }
            else{
                charNum[line[i]]++; // Otherwise add 1 to that characters value
            }
        }
        Console.WriteLine("Here are the occurences: " );
        foreach (var kvp in charNum)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

    }

    // This function reverses each individual word on a line
    public void revWords(){
        Console.WriteLine("Write a sentence:");
        string line = Console.ReadLine();
        string revLine = "";
         int temp = 0;
        for(int i = 0; i < line.Length; i++){
            temp++;
            if(line[i] == ' '){ // At each space it creates a substring of the characters previous to that space and reverses them
                revLine += revWord(line.Substring(i-temp+1,temp-1)) + " ";
                temp = 0;
            }
            if(i == line.Length-1){ // A final clause since there is no space at the end of most lines
                revLine += revWord(line.Substring(i-temp+1,temp));
            }
            
        }
        
        Console.WriteLine("Here's your sentence with every word reversed:");
        Console.WriteLine(revLine);
    }

    // Reverses a string, helper function for revWords
    private string revWord(string word){
        char [] reverse = word.ToCharArray();
        char temp;
        for(int i = 0; i < word.Length / 2; i++){ // A basic character swap between two locations
            temp = reverse[i];
            reverse[i] = reverse[reverse.Length-i-1];
            reverse[reverse.Length-i-1] = temp;
        }

        return new string (reverse);
    }

    // This functions reverses the words in a sentence i.e. "i have the high ground" turns into "ground high the have i"
    public void revSentence(){
        Console.WriteLine("Write a sentence:");
        string line = Console.ReadLine();
        string revLine = "";
        int temp = 0;
        for(int i = line.Length-1; i >= 0; i--){ // Loops through line starting at last word
            temp++;
            if(line[i] == ' '){// If space then the word that was just scaned over is added to revLine string
                revLine += line.Substring(i+1,temp-1) + " ";
                temp = 0;
            }
            if(i == 0){ // Final case for when its the first word on the line
                revLine += line.Substring(i,temp);
            }
        }
        Console.WriteLine("This is your line backwards:");
        Console.WriteLine(revLine);
    }

    // Checks to see if an entered word or phrase is a palindrome i.e. "mom"
    public void palindrome(){
        Console.WriteLine("Write a word");
        string line = Console.ReadLine();
        int pal = 0;
        // Checks each corresponding letter with its "partner" at the other end of the string
        for(int i = 0; i < line.Length / 2 ; i++){
            if(line[i] != line[line.Length-i-1]){
                pal = 1;
            }
        }
        if(pal == 0){
            Console.WriteLine("You have a palindrome: " + line);
        }
        else{
            Console.WriteLine(line + " is not a palindrome");
        }
    }
    
    // Reverses any word or phrase in all characters
    public void reverse(){
        Console.WriteLine("Write a word");
        string line = Console.ReadLine();
        char [] reverse = line.ToCharArray();
        char temp;
        for(int i = 0; i < line.Length / 2; i++){ // Swaps out corresponding letters
            temp = reverse[i]; 
            reverse[i] = reverse[reverse.Length-i-1];
            reverse[reverse.Length-i-1] = temp;
        }
        Console.WriteLine("Here is your word reversed:");
        line = new string (reverse);
        Console.WriteLine(line);

    }
}