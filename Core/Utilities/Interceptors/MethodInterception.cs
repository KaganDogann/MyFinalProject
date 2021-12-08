using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation) //burada ki invocation benim çalıştırmak istediğim metodum oluyor.
        {
            var isSuccess = true;
            OnBefore(invocation);//invocation!ı nerede çalıştırmak istersin OnBefore dersen metodun başında çalıştır demek.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//hata alırsa çalışsın
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//başarılı olursa çalışsın
                }
            }
            OnAfter(invocation);//metottdan sonra çalışsın
        }
    }
}
