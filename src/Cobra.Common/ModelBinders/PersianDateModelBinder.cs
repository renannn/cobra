using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Cobra.Common
{
    /// <summary>
    /// Persian Date Model Binder
    /// </summary>
    public class PersianDateModelBinder : IModelBinder
    {
        /// <summary>
        /// Attempts to bind a model.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA1031:catch a more specific allowed exception type, or rethrow the exception",
                Justification = "The exception will be logged.")]
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var logger = bindingContext.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
            var binderLogger = logger.CreateLogger(nameof(PersianDateModelBinder));

            var fallbackBinder = new SimpleTypeModelBinder(bindingContext.ModelType, logger);

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                binderLogger.LogError("PersianDateModelBinder error",
                    $"There is not valueProvider for bindingContext.ModelName:`{bindingContext.ModelName}`.");
                return fallbackBinder.BindModelAsync(bindingContext);
            }
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

            DateTime? dt;
            try
            {
                var valueAsString = valueProviderResult.FirstValue;

                if (!DateTime.TryParse(valueAsString, out DateTime tmp))
                {
                    binderLogger.LogError("PersianDateModelBinder error",
                        $"`{valueAsString}` is not a valid PersianDateTime.");

                    return fallbackBinder.BindModelAsync(bindingContext);
                }
                dt = tmp;
            }
            catch (Exception ex)
            {
                var message = $"`{valueProviderResult.FirstValue}` is not a valid Persian date.";
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);

                binderLogger.LogError("PersianDateModelBinder error", ex.Demystify(), message);

                return Task.CompletedTask;
            }

            if (Nullable.GetUnderlyingType(bindingContext.ModelType) == typeof(DateTime))
            {
                bindingContext.Result = ModelBindingResult.Success(dt);
            }
            else if (dt.HasValue)
            {
                bindingContext.Result = ModelBindingResult.Success(dt.Value);
            }
            return Task.CompletedTask;
        }
    }
}