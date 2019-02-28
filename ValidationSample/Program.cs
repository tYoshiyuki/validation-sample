using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationSample.Models;

namespace ValidationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 検証用データの準備
            var blogs = new List<Blog>
            {
                new Blog {Author = "TaroTaroTaroTaroTaroTaro", Name = "Hoge"},
                new Blog {Id = 2, Author = null, Name = "Fuga"},
                new Blog {Id = 3, Author = "Jiro", Name = null}
            };

            var result = new Dictionary<int, List<ValidationResult>>();
            var i = 1;

            // 検証の実施
            foreach (var blog in blogs)
            {
                var validationResults = new List<ValidationResult>();
                var contexts = new ValidationContext(blog, null, null);
                var isValid = Validator.TryValidateObject(blog, contexts, validationResults, true);
                if (!isValid)
                {
                    result.Add(i, validationResults);
                }
                i++;
            }

            // 検証結果の出力
            foreach (var r in result)
            {
                r.Value.ForEach(_ => Console.WriteLine($"Line:{r.Key} Error:{_.ErrorMessage}"));
            }
        }
    }
}
