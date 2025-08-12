using GreenDonut;
using RF.Ecom.Core.Features.Orders.Implementations;

[assembly: DataLoaderModule(nameof(ItemsDataLoader))]
[assembly: DataLoaderDefaults(AccessModifier = DataLoaderAccessModifier.Internal)]