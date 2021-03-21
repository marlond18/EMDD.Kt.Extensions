using System;

namespace KtExtensions
{
    /// <summary>
    /// Improved Action methods
    /// </summary>
    public static class MethodShortcuts
    {
        /// <summary>
        /// Runs based on a the condition of <paramref name="condition"/>,
        /// runs <paramref name="ifTrue"/> if <paramref name="condition"/> is true and
        /// runs <paramref name="ifFalse"/> if <paramref name="condition"/> is false
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifTrue"></param>
        /// <param name="ifFalse"></param>
        public static void BoolAction(bool condition, Action ifTrue, Action ifFalse)
        {
            if (ifTrue == null || ifFalse == null) return;
            if (condition)
            {
                ifTrue();
            }
            else
            {
                ifFalse();
            }
        }

        /// <summary>
        /// Chainable initial values to func
        /// </summary>
        /// <typeparam name="Tseed"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed, Tresult>(Func<Tseed> seed, Func<Tseed, Tresult> result) =>
            result == null ? default : result(seed == null ? default : seed.Invoke());

        /// <summary>
        /// Chainable initial values to func
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed1"></param>
        /// <param name="seed2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tresult>(Func<Tseed1> seed1, Func<Tseed2> seed2, Func<Tseed1, Tseed2, Tresult> result) =>
            result == null ? default : result(seed1 == null ? default : seed1(), seed2 == null ? default : seed2());

        /// <summary>
        /// Chainable initial values to func
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tseed3"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed1"></param>
        /// <param name="seed2"></param>
        /// <param name="seed3"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tseed3, Tresult>(Func<Tseed1> seed1, Func<Tseed2> seed2, Func<Tseed3> seed3, Func<Tseed1, Tseed2, Tseed3, Tresult> result) =>
            result == null ? default : result(seed1 == null ? default : seed1(), seed2 == null ? default : seed2(), seed3 == null ? default : seed3());

        /// <summary>
        /// Chainable initial values to func
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tseed3"></typeparam>
        /// <typeparam name="Tseed4"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed1"></param>
        /// <param name="seed2"></param>
        /// <param name="seed3"></param>
        /// <param name="seed4"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tseed3, Tseed4, Tresult>(Func<Tseed1> seed1, Func<Tseed2> seed2, Func<Tseed3> seed3, Func<Tseed4> seed4, Func<Tseed1, Tseed2, Tseed3, Tseed4, Tresult> result) =>
            result == null ? default : result(
                seed1 == null ? default : seed1(),
                seed2 == null ? default : seed2(),
                seed3 == null ? default : seed3(),
                seed4 == null ? default : seed4());

        /// <summary>
        /// Chainable initial values to func: 5 seed elements
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tseed3"></typeparam>
        /// <typeparam name="Tseed4"></typeparam>
        /// <typeparam name="Tseed5"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed1"></param>
        /// <param name="seed2"></param>
        /// <param name="seed3"></param>
        /// <param name="seed4"></param>
        /// <param name="seed5"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tseed3, Tseed4, Tseed5, Tresult>(Func<Tseed1> seed1, Func<Tseed2> seed2, Func<Tseed3> seed3, Func<Tseed4> seed4, Func<Tseed5> seed5, Func<Tseed1, Tseed2, Tseed3, Tseed4, Tseed5, Tresult> result) =>
            result == null ? default : result(
                seed1 == null ? default : seed1(),
                seed2 == null ? default : seed2(),
                seed3 == null ? default : seed3(),
                seed4 == null ? default : seed4(),
                seed5 == null ? default : seed5());

        /// <summary>
        /// Chainable initial values to func
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tresult>(Func<(Tseed1, Tseed2)> seed, Func<Tseed1, Tseed2, Tresult> result) =>
            SeedProcess(seed,
                s => result == null ? default : result(s.Item1, s.Item2));

        /// <summary>
        /// Chainable initial values to func: Tuple of 3
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tseed3"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tseed3, Tresult>(Func<(Tseed1, Tseed2, Tseed3)> seed, Func<Tseed1, Tseed2, Tseed3, Tresult> result) =>
            SeedProcess(seed,
                s => result == null ? default : result(s.Item1, s.Item2, s.Item3));

        /// <summary>
        /// Chainable initial values to func: Tuple of 4
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tseed3"></typeparam>
        /// <typeparam name="Tseed4"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tseed3, Tseed4, Tresult>(Func<(Tseed1, Tseed2, Tseed3, Tseed4)> seed, Func<Tseed1, Tseed2, Tseed3, Tseed4, Tresult> result) =>
            SeedProcess(seed,
                s => result == null ? default : result(s.Item1, s.Item2, s.Item3, s.Item4));

        /// <summary>
        /// Chainable initial values to func: Tuple of 5
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tseed3"></typeparam>
        /// <typeparam name="Tseed4"></typeparam>
        /// <typeparam name="Tseed5"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tseed3, Tseed4, Tseed5, Tresult>(Func<(Tseed1, Tseed2, Tseed3, Tseed4, Tseed5)> seed, Func<Tseed1, Tseed2, Tseed3, Tseed4, Tseed5, Tresult> result) =>
            SeedProcess(seed,
                s => result == null ? default : result(s.Item1, s.Item2, s.Item3, s.Item4, s.Item5));

        /// <summary>
        /// Chainable initial values to func
        /// </summary>
        /// <typeparam name="Tseed1"></typeparam>
        /// <typeparam name="Tseed2"></typeparam>
        /// <typeparam name="Tseed3"></typeparam>
        /// <typeparam name="Tseed4"></typeparam>
        /// <typeparam name="Tresult"></typeparam>
        /// <param name="seed1"></param>
        /// <param name="seed2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Tresult SeedProcess<Tseed1, Tseed2, Tseed3, Tseed4, Tresult>(Func<(Tseed1, Tseed2)> seed1, Func<(Tseed3, Tseed4)> seed2, Func<Tseed1, Tseed2, Tseed3, Tseed4, Tresult> result) =>
            SeedProcess(seed1, seed2,
                (s1, s2) => result == null ? default : result(s1.Item1, s1.Item2, s2.Item1, s2.Item2));

        /// <summary>
        /// Inception type of function. create a value null, assign a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T Recursion<T>(Func<Func<T>, T> func) where T : class
        {
            T d = null;
            d = func?.Invoke(() => d);
            return d;
        }
    }
}