namespace Triangle.Triangle
{
    public class TriangleType
    {
        private int[] _sides;

        /// <summary>
        /// constructor 1: Constructor by array
        /// </summary>
        /// <param name="sides">Array with 3 sides of a triangle</param>
        /// <exception cref="System.ArgumentException">Incorrect number of elements in the array</exception>
        public TriangleType(int[] sides)
        {
            ArrayValidation(sides);

            _sides = sides;
        }

        public TriangleType(int A, int B, int C)
        {
            _sides = new int[3];

            _sides[0] = A;
            _sides[1] = B;
            _sides[2] = C;
        }

        public bool IsTriangle()
        {
            return IsTriangle(_sides[0], _sides[1], _sides[2]);
        }

        public static bool IsTriangle(int[] sides)
        {
            ArrayValidation(sides);

            return IsTriangle(sides[0], sides[1], sides[2]);
        }

        public static bool IsTriangle(int A, int B, int C)
        {
            if(A < 1 || B < 1 || C < 1)
                return false;

            return  ((long)A + (long)B) > (long)C &&
                    ((long)A + (long)C) > (long)B &&
                    ((long)B + (long)C) > (long)A;
        }

        public bool IsEquilateralTriangle()
        {
            return IsEquilateralTriangle(_sides[0], _sides[1], _sides[2]);
        }

        public static bool IsEquilateralTriangle(int[] sides)
        {
            ArrayValidation(sides);

            return IsEquilateralTriangle(sides[0], sides[1], sides[2]);
        }

        public static bool IsEquilateralTriangle(int A, int B, int C)
        {
            if (!IsTriangle(A, B, C))
                return false;

            return A == B && A == C;
        }

        public bool IsIsocelesTriangle()
        {
            return IsIsocelesTriangle(_sides[0], _sides[1], _sides[2]);
        }

        public static bool IsIsocelesTriangle(int[] sides)
        {
            ArrayValidation(sides);

            return IsIsocelesTriangle(sides[0], sides[1], sides[2]);
        }

        public static bool IsIsocelesTriangle(int A, int B, int C)
        {
            if(!IsTriangle(A, B, C))
                return false;

            return A == B || A == C || B == C;
        }

        public bool IsScalenoTriangle()
        {
            return IsScalenoTriangle(_sides[0], _sides[1], _sides[2]);
        }

        public static bool IsScalenoTriangle(int[] sides)
        {
            ArrayValidation(sides);

            return IsScalenoTriangle(sides[0], sides[1], sides[2]);
        }

        public static bool IsScalenoTriangle(int A, int B, int C)
        {
            return A != B && A != C && B != C && IsTriangle(A, B, C);
        }

        public bool IsRightTriangle()
        {
            return IsRightTriangle(_sides[0], _sides[1], _sides[2]);
        }

        public static bool IsRightTriangle(int[] sides)
        {
            ArrayValidation(sides);

            return IsRightTriangle(sides[0], sides[1], sides[2]);
        }

        public static bool IsRightTriangle(int A, int B, int C)
        {
            if (!IsTriangle(A, B, C))
                return false;

            var hip = LargestOfThree(A, B, C);

            return  (((long)hip == (long)A) && ((long)A * (long)A == (long)B * (long)B + (long)C * (long)C)) ||
                    (((long)hip == (long)B) && ((long)B * (long)B == (long)A * (long)A + (long)C * (long)C)) ||
                    (((long)hip == (long)C) && ((long)C * (long)C == (long)A * (long)A + (long)B * (long)B));
        }

        public bool IsAcuteTriangle()
        {
            return IsAcuteTriangle(_sides[0], _sides[1], _sides[2]);
        }

        public static bool IsAcuteTriangle(int[] sides)
        {
            ArrayValidation(sides);

            return IsAcuteTriangle(sides[0], sides[1], sides[2]);
        }

        public static bool IsAcuteTriangle(int A, int B, int C)
        {
            if (!IsTriangle(A, B, C))
                return false;

            var largest = LargestOfThree(A, B, C);

            return  (((long)largest == (long)A) && ((long)A * (long)A < (long)B * (long)B + (long)C * (long)C)) ||
                    (((long)largest == (long)B) && ((long)B * (long)B < (long)A * (long)A + (long)C * (long)C)) ||
                    (((long)largest == (long)C) && ((long)C * (long)C < (long)A * (long)A + (long)B * (long)B));
        }

        public bool IsObtuseTriangle()
        {
            return IsObtuseTriangle(_sides[0], _sides[1], _sides[2]);
        }

        public static bool IsObtuseTriangle(int[] sides)
        {
            ArrayValidation(sides);

            return IsObtuseTriangle(sides[0], sides[1], sides[2]);
        }

        public static bool IsObtuseTriangle(int A, int B, int C)
        {
            if (!IsTriangle(A, B, C))
                return false;

            var largest = LargestOfThree(A, B, C);

            return  (((long)largest == (long)A) && ((long)A * (long)A > (long)B * (long)B + (long)C * (long)C)) ||
                    (((long)largest == (long)B) && ((long)B * (long)B > (long)A * (long)A + (long)C * (long)C)) ||
                    (((long)largest == (long)C) && ((long)C * (long)C > (long)A * (long)A + (long)B * (long)B));
        }

        public TriangleTypes[] GetTriangleTypes()
        {
            return GetTriangleTypes(_sides[0], _sides[1], _sides[2]);
        }

        public static TriangleTypes[] GetTriangleTypes(int[] sides)
        {
            ArrayValidation(sides);

            return GetTriangleTypes(sides[0], sides[1], sides[2]);
        }

        public static TriangleTypes[] GetTriangleTypes(int A, int B, int C)
        {
            //verification 1: Is triangle
            if (!IsTriangle(A, B, C))
                return new TriangleTypes[] { TriangleTypes.IS_NOT_TRIANGLE };

            //verification 2: Is equilateral triangle (consequently isoceles and acutangle)
            if (IsEquilateralTriangle(A, B, C))
                return new TriangleTypes[] { TriangleTypes.EQUILATERAL_TRIANGLE, TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.ACUTE_TRIANGLE };

            //verification 3: Is isoceles triangle (consequently right or acute or obtuse)
            if (IsIsocelesTriangle(A, B, C))
                if(IsRightTriangle(A, B, C))
                    return new TriangleTypes[] { TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.RIGHT_TRIANGLE };
                else if(IsAcuteTriangle(A, B, C))
                    return new TriangleTypes[] { TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.ACUTE_TRIANGLE };
                else
                    return new TriangleTypes[] { TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.OBTUSE_TRIANGLE };

            //verification 4: is scaleno triangle (consequently right or acute or obtuse)
            if (IsScalenoTriangle(A, B, C))
                if (IsRightTriangle(A, B, C))
                    return new TriangleTypes[] { TriangleTypes.SCALENE_TRIANGLE, TriangleTypes.RIGHT_TRIANGLE };
                else if (IsAcuteTriangle(A, B, C))
                    return new TriangleTypes[] { TriangleTypes.SCALENE_TRIANGLE, TriangleTypes.ACUTE_TRIANGLE };
                else
                    return new TriangleTypes[] { TriangleTypes.SCALENE_TRIANGLE, TriangleTypes.OBTUSE_TRIANGLE };

            throw new System.Exception();
        }

        private static void ArrayValidation(int[] sides)
        {
            if (sides.Length != 3)
                throw new System.ArgumentException("Incorrect number of elements in the list");
        }

        private static int LargestOfThree(int A, int B, int C)
        {
            if (A > B)
                if (A > C)
                    return A;
                else
                    return C;
            else if(B > C)
                return B;
            else
                return C;
        }
    }
}
