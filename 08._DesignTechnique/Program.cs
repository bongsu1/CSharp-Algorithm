﻿using System.Security.Cryptography;

namespace _08._DesignTechnique
{
    internal class Program
    {
        /*******************************************************************************************
         * 알고리즘 설계기법 (Algorithm Design Technique)
         * 
         * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
         * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
         * 문제의 성질과 조건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용
         ********************************************************************************************/


        /******************************************************
         * 재귀 (Recursion)
         * 
         * 어떠한 것을 정의할 때 자기 자신을 참조하는 것
         * 함수를 정의할 때 자기자신을 이용하여 표현하는 방법
         ******************************************************/

        // <재귀함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함


        // <재귀함수 사용>
        // Factorial : 정수를 1이 될 때까지 차감하여 곱한 값
        // x! = x * (x-1)!;
        // 1! = 1;
        // ex) 5! = 5 * 4!
        //        = 5 * 4 * 3!
        //        = 5 * 4 * 3 * 2!
        //        = 5 * 4 * 3 * 2 * 1!
        //        = 5 * 4 * 3 * 2 * 1

        static int Factorial(int x)
        {
            if (x == 1)
                return 1;
            else
                return x * Factorial(x - 1);
        }
        
        // 예시 - 폴더삭제
        void RemoveDir(Directory directory)
        {
            foreach(Directory dir in directory.childDir)
            {
                RemoveDir(dir);
            }

            Console.WriteLine("폴더 내 파일 모두 삭제");
        }

        struct Directory
        {
            public List<Directory> childDir;
        }
        static void Main(string[] args)
        {
            Factorial(5);
        }
    }
}
