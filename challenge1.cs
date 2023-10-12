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
        tester.uniqueChars();
    }

    public void uniqueChars(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        List<char> chars = new List<char>();
        int longest = 0;
        int flag = 0;
        string current = "";
        string longUni = "";
        for(int i = 0; i < line.Length; i++){
            for(int j = 1; j <= line.Length-i;j++){
                if(j > longest){
                    current = line.Substring(i,j);
                    for(int k = 0; k < current.Length; k++){
                        if(!chars.Contains(current[k])){
                            chars.Add(current[k]);
                        }
                        else{
                            flag = 1;
                            break;
                        }
                    }
                    if(flag == 1){
                        flag = 0;
                    }
                    else{
                        longest = j;
                        longUni = current;
                    }
                    chars.Clear();
                        
                }
            }
        }
        Console.WriteLine("The Longest unique substring is: ");
        Console.WriteLine(longUni);
        Console.WriteLine("With " + longest + " characters.");
    }
    public void allSubs(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        Console.WriteLine("Here is all substrings for the line");
        for(int i = 0; i < line.Length; i++){
            for(int j = 1; j <= line.Length - i; j++){
                Console.Write(line.Substring(i,j) + " ");
            }

        }
    }


    public void remDupes(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        string noDupes = "";
        List<char> chars = new List<char>();
        for(int i = 0; i < line.Length; i++){
            if(!chars.Contains(line[i]) && line[i] != ' '){
                noDupes += line[i];
                chars.Add(line[i]);
            }
            else if(line[i] == ' '){
                noDupes+=line[i];
            }
        }

        Console.WriteLine("Here's your string without duplicates");
        Console.WriteLine(noDupes);

    }

    public void charCounter(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        Dictionary<char, int> charNum = new Dictionary<char, int>();
        for(int i = 0; i < line.Length; i++){
            if(line[i] == ' '){
                continue;
            }
            else if(!charNum.ContainsKey(line[i])){
                charNum.Add(line[i],1);
            }
            else{
                charNum[line[i]]++;
            }
        }
        Console.WriteLine("Here are the occurences: " );
        foreach (var kvp in charNum)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

    }

    public void revWords(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        string revLine = "";
         int temp = 0;
        for(int i = 0; i < line.Length; i++){
            temp++;
            if(line[i] == ' '){
                revLine += revWord(line.Substring(i-temp+1,temp-1)) + " ";
                temp = 0;
            }
            if(i == line.Length-1){
                revLine += revWord(line.Substring(i-temp+1,temp));
            }
            
        }
        
        Console.WriteLine("Here's your sentence with every word reversed:");
        Console.WriteLine(revLine);
    }

    private string revWord(string word){
        char [] reverse = word.ToCharArray();
        char temp;
        for(int i = 0; i < word.Length / 2; i++){
            temp = reverse[i];
            reverse[i] = reverse[reverse.Length-i-1];
            reverse[reverse.Length-i-1] = temp;
        }

        return new string (reverse);
    }

    public void revSentence(){
        Console.WriteLine("Write a word:");
        string line = Console.ReadLine();
        string revLine = "";
        int temp = 0;
        for(int i = line.Length-1; i >= 0; i--){
            temp++;
            if(line[i] == ' '){
                revLine += line.Substring(i+1,temp-1) + " ";
                temp = 0;
            }
        }
        Console.WriteLine("This is your line backwards:");
        Console.WriteLine(revLine);
    }
    public void palindrome(){
        Console.WriteLine("Write a word");
        string line = Console.ReadLine();
        int pal = 0;
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
    
    public void reverse(){
        Console.WriteLine("Write a word");
        string line = Console.ReadLine();
        char [] reverse = line.ToCharArray();
        char temp;
        for(int i = 0; i < line.Length / 2; i++){
            temp = reverse[i];
            reverse[i] = reverse[reverse.Length-i-1];
            reverse[reverse.Length-i-1] = temp;
        }
        Console.WriteLine("Here is your word reversed:");
        line = new string (reverse);
        Console.WriteLine(line);

    }
}