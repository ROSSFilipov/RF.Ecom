using GreenDonut;
using RF.Ecom.Core.Features.Orders.Implementations;

[assembly: DataLoaderModule(nameof(ItemsDataLoader), IsInternal = true)]
[assembly: DataLoaderDefaults(AccessModifier = DataLoaderAccessModifier.Internal)]