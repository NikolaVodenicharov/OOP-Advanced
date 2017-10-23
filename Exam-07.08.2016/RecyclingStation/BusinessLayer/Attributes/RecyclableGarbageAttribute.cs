namespace RecyclingStation.BusinessLayer.Attributes
{
    using System;
    using WasteDisposal.Attributes;

    public class RecyclableGarbageAttribute : DisposableAttribute
    {
        public RecyclableGarbageAttribute(Type correspondingStrategyType) 
            : base(correspondingStrategyType)
        {
        }
    }
}
