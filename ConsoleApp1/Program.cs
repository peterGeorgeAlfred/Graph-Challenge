using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        //static string[] input = { "4", "A", "B", "C", "D", "A-B", "A_B", "B-C", "C-D" };
        static string[] input = { "7", "A", "B", "C", "D", "E", "F", "G", "A-B", "A-E", "A-F","B-C", "C-D", "D-F", "E-D", "F-G" };
        //static string[] input = { "4", "X", "Y", "Z", "W", "A-B", "A-E", "X-Y", "Y-Z","X-W"};
        //static string[] input = { "5", "A", "B", "C", "D","F", "A-B", "A-C", "B-C", "C-D","D-F"};

        static int length;
        static string fixedFirst;
        static string fixedLast;
        static  Dictionary<string, List<string>> FamilyTree = new Dictionary<string, List<string>>();
        static List<string> paths = new List<string>(); 

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            length = int.Parse(input[0]);
            fixedFirst = input[1];
            fixedLast = input[length];
            List<string> Chars = new List<string>();
            List<string> Connections = new List<string>();

            for (int i = 1; i <= length; i++)
            {
                Chars.Add(input[i]);
            }
            for (int i = length + 1; i < input.Length; i++)
            {
                Connections.Add(input[i]);
            }

            fillTreefamily(Chars, Connections);
            intialPath(fixedFirst);
            CompletePath(isFinished());

            RemoveNotValidPath();
            string  path =  findSmallestPath();
          
           

            Console.WriteLine(path);
            


            Console.ReadLine();

        }

        static void fillTreefamily(List<string> chars , List<string> conns)
        {
            foreach (var ch in chars)
            {
                List<string> childrens =  findChildren(ch, conns);
                FamilyTree.Add(ch, childrens); 
            }
        }
        static List<string> findChildren(string parent , List<string> conns)
        {
            List<string> children = new List<string>();
            foreach (var conn in conns)
            {
                if (conn[0].ToString() == parent)
                    children.Add(conn[2].ToString()); 
            }
            return children; 
        }

        static void intialPath(string path )
        {
            string parent = path[path.Length - 1].ToString(); 
            List<string> children = FamilyTree.GetValueOrDefault(parent);
            foreach (var child in children) 
            {
                             
                paths.Add($"{path}-{child}");
                
            }
            if(! (path[path.Length-1].ToString() == fixedLast) )
            paths.Remove(path); 

           
        }
        static void CompletePath(bool isCompleted)
        {
            

            while(!isCompleted)
            {
                for (int i = 0; i < paths.Count; i++)
                {
                    intialPath(paths[i]);
                }             
               
                    

                
                isCompleted = isFinished();
            }
           
        }

        static bool isFinished()
        {
            foreach (var path in paths)
            {
                char lastChar = path[path.Length - 1];
                if (lastChar.ToString() == fixedLast)
                    return true; 
            }
            return false; 
        }

        static void RemoveNotValidPath()
        {
            for (int i = 0; i < paths.Count; i++)
            {
                if (!(paths[i][paths[i].Length - 1].ToString() == fixedLast))
                    paths.Remove(paths[i]); 
            }
        }

        static string findSmallestPath()
        {
            int min = length;
            string result = string.Empty;
            foreach (var path in paths)
            {
                if( path.Length < min )
                {
                    min = path.Length;
                    result = path; 
                }
            }
            return result; 
                
        }


       
    }
}
