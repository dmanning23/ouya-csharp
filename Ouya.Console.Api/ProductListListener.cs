using System.Threading.Tasks;
using Android.Runtime;
using System.Collections.Generic;

namespace Ouya.Console.Api
{
    class ProductListListener : global::Java.Lang.Object, IOuyaResponseListener
    {
        TaskCompletionSource<IList<Product>> _tcs;

        public ProductListListener(TaskCompletionSource<IList<Product>> tcs)
        {
            _tcs = tcs;
        }

        public void OnCancel()
        {
            _tcs.SetCanceled();
        }

        public void OnFailure(int errorCode, string errorMessage, global::Android.OS.Bundle optionalData)
        {
            _tcs.SetException(new OuyaRequestException(errorCode, errorMessage));
        }

        public void OnSuccess(global::Java.Lang.Object result)
        {
            var list = result.JavaCast<JavaList<Product>>();
            _tcs.SetResult(list);
        }
    }
}