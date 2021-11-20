//using System;
//using System.Collections.Generic;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        //static string[] input = { "4", "A", "B", "C", "D", "A-B", "A_B", "B-C", "C-D" };
//        static string[] input = { "7", "A", "B", "C", "D", "E", "F", "G", "A-B", "A-E", "A-F","B-C", "C-D", "D-F", "E-D", "F-G" };
//        //static string[] input = { "4", "X", "Y", "Z", "W", "A-B", "A-E", "X-Y", "Y-Z","X-W"};
//        //static string[] input = { "5", "A", "B", "C", "D","F", "A-B", "A-C", "B-C", "C-D","D-F"};

//        static int length;
//        static string fixedFirst;
//        static string fixedLast;      
//        static string path = string.Empty;
//        static List<string> paths = new List<string>(); 


//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//            length = int.Parse(input[0]);
//            fixedFirst = input[1];
//            fixedLast = input[length];
//            List<string> Chars = new List<string>();
//            List<string> Connections = new List<string>();

//            for (int i = 1; i <= length; i++)
//            {
//                Chars.Add(input[i]);
//            }
//            for (int i = length + 1; i < input.Length; i++)
//            {
//                Connections.Add(input[i]);
//            }

            

//            CreatePath(Chars, Connections, fixedLast);

//            foreach (var path in paths)
//            {

//                Console.WriteLine(path);
//            }


//            Console.ReadLine();

//        }


//        static void CreatePath(List<string> Chars, List<string> Connections, string last)
//        {
//            foreach (var item in Chars)
//            {
//                string conn = $"{item}-{last}";
//                bool isFound = searchConn(conn, Connections);
//                if (isFound)
//                {
//                    Connections.Remove(conn);
//                    bool isFirst = isGetFirst(conn);
//                    if (isFirst)
//                    {
//                        if(string.IsNullOrEmpty(path))
//                        {
//                            //Console.WriteLine(conn);
//                            paths.Add(path);
//                            return;

//                        }

//                        else
//                        {
//                            path = $"{conn[0]}-{path}";
//                            //Console.WriteLine(path);
//                            paths.Add(path);

                            
//                            return; 
//                        }
//                    }
//                    else
//                    {
//                        if (string.IsNullOrEmpty(path))
//                            path = conn;
//                        else
//                            path = $"{conn[0]}-{path}"; 
//                        string first = conn[0].ToString();
//                        CreatePath(Chars, Connections, first);
//                    }

//                }

//            }

//        }

//        static bool searchConn(string path, List<string> conns)
//        {
//            foreach (var item in conns)
//            {
//                if (item == path)
//                    return true;


//            }
//            return false;
//        }
//        static bool isGetFirst(string conn)
//        {
//            if (conn[0].ToString() == fixedFirst)
//                return true;

//            return false;
//        }
//    }
//}
