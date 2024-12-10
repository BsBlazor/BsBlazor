//using FluentValidation;
//using FluentValidation.Validators;
//using System.Linq.Expressions;
//namespace BlazorDevKit.FluentValidation.Base;

//internal static class RequiredTracker
//{
//    public static void VerifyRequired<T, TProperty>(Func<ValidationContext<T>, TProperty, bool> isValid, ValidationContext<T> context)
//    {
//        if (context.RootContextData.TryGetValue("Requireds", out object? requiredsInstance) && !isValid(context, default!))
//        {
//            try
//            {
//                var requireds = (HashSet<(object model, string fieldName)>)requiredsInstance;
//                var propertyChainNames = context.PropertyChain.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries).ToList();
//                var propertiesNames = context.PropertyPath.Split('.', StringSplitOptions.RemoveEmptyEntries).ToList();
//                var complexProperties = propertiesNames.Take(propertiesNames.Count - 1);
//                var field = propertiesNames.LastOrDefault("");
//                object instanceToValidate = context.InstanceToValidate!;
//                foreach (var complexProperty in complexProperties)
//                {
//                    if (propertyChainNames.Count > 0 && propertyChainNames[0] == complexProperty)
//                    {

//                        propertyChainNames.RemoveAt(0);
//                        continue;
//                    }
//                    instanceToValidate = instanceToValidate.GetType().GetProperty(complexProperty)!.GetValue(instanceToValidate)!;
//                }
//                requireds.Add((instanceToValidate!, field));
//            }
//            catch
//            {
//                Console.WriteLine($"Tracking required not supported in this context. {typeof(T).Name} {context.PropertyPath}");
//            }
//        }
//    }

//    public static void VerifyRequired2<T, TProperty>(IValidationRule<T> rule, IPropertyValidator<T, TProperty> validator, ValidationContext<T> context)
//    {
//        if (context.RootContextData.TryGetValue("Requireds", out object? requiredsInstance) && !validator.IsValid(context, default!))
//        {
//            try
//            {
//                var memberExpression = rule.Expression.Body as MemberExpression ?? (rule.Expression.Body as UnaryExpression)?.Operand as MemberExpression;
//                if (memberExpression == null)
//                {
//                    throw new ArgumentException("Expression must be a member expression");
//                }
//                var targetModel = Expression.Lambda(memberExpression.Expression!, rule.Expression.Parameters).Compile().DynamicInvoke(context.InstanceToValidate);
//                var requireds = (HashSet<(object model, string fieldName)>)requiredsInstance;
//                requireds.Add((targetModel!, memberExpression.Member.Name));

//                //var requireds = (HashSet<(object model, string fieldName)>)requiredsInstance;
//                //var propertyChainNames = context.PropertyChain.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries).ToList();
//                //var propertiesNames = context.PropertyPath.Split('.', StringSplitOptions.RemoveEmptyEntries).ToList();
//                //var complexProperties = propertiesNames.Take(propertiesNames.Count - 1);
//                //var field = propertiesNames.LastOrDefault("");
//                //object instanceToValidate = context.InstanceToValidate!;
//                //foreach (var complexProperty in complexProperties)
//                //{
//                //    if (propertyChainNames.Count > 0 && propertyChainNames[0] == complexProperty)
//                //    {

//                //        propertyChainNames.RemoveAt(0);
//                //        continue;
//                //    }
//                //    instanceToValidate = instanceToValidate.GetType().GetProperty(complexProperty)!.GetValue(instanceToValidate)!;
//                //}
//                //requireds.Add((instanceToValidate!, field));
//            }
//            catch
//            {
//                Console.WriteLine($"Tracking required not supported in this context. {typeof(T).Name} {context.PropertyPath}");
//            }
//        }
//    }
//}