namespace SystemDot.Mobile.Mvvm.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SystemDot.Core.Collections;

    public static class EnumerableStringExtensions
    {
        public static void OutputValidationToViewModel<TViewModel, TProperty>(
            this IEnumerable<string> messages,
            TViewModel viewModel,
            Func<TViewModel, TProperty> property)
            where TViewModel : ValidatableViewModel<TViewModel>
            where TProperty : IInvalidatableInput
        {
            if (!messages.Any()) return;
                
            ExclusiveRunLock.Run(() =>
            {
                messages.ForEach(m => viewModel.ValidationMessage.Value = m);
                property.Invoke(viewModel).Invalidate();
            });

        }

        public static void OutputValidationToViewModel<TViewModel>(
            this IEnumerable<string> messages,
            TViewModel viewModel)
            where TViewModel : ValidatableViewModel<TViewModel>
        {
            if (!messages.Any()) return;

            ExclusiveRunLock.Run(() =>
            {
                messages.ForEach(m => viewModel.ValidationMessage.Value = m);
            });
        }
    }
}