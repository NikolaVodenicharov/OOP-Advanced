namespace RecyclingStation.BusinessLayer.Attributes
{
    using System;
    using WasteDisposal.Attributes;

    public class BurnableGarbageAttribute : DisposableAttribute
    {
        public BurnableGarbageAttribute(Type correspondingStrategyType) 
            : base(correspondingStrategyType)
        {
        }
    }
}
