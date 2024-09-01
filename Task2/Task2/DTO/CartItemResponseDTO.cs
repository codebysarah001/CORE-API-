namespace Task2.DTO
{
    public class CartItemResponseDTO
    {
        public int CartItemId { get; set; }

        public int? CartId { get; set; }

        public int Quantity { get; set; }

        public ProductDTO? Product { get; set; }


    }
}
