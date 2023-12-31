import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    products: [],
    loading: false,
    error: null,
    productToEdit: null,
};

const productsSlice = createSlice({
    name: "products",
    initialState,
    reducers: {
        getProductsStart(state) {
            state.loading = true;
        },
        getProductsSuccess(state, action) {
            const cart = JSON.parse(localStorage.getItem("cart"));
            const productsInCartIds = cart ? cart.orderLines.map((ol) => ol.productId) : [];
            state.products = action.payload
                .map((product) => ({ ...product, isFilteredOut: 0, isInCart: productsInCartIds.includes(product.id) }));
            state.loading = false;
            state.error = null;
        },
        getProductsFailure(state, action) {
            state.loading = false;
            state.error = action.payload;
        },
        setProductToEdit(state, action) {
            state.productToEdit = action.payload;
        },
        addProduct(state, action) {
            const newProduct = action.payload;
            state.products = [newProduct, ...state.products];
        },
        updateProduct(state, action) {
            const updatedProduct = action.payload;
            state.products = state.products.map((product) =>
                product.id === updatedProduct.id ? updatedProduct : product
            );
            state.productToEdit = null;
        },
        deleteProduct(state, action) {
            const productId = action.payload;
            state.products = state.products.filter((product) => product.id !== productId);
        },
        filterProducts(state, action) {
            const { maxPrice, minRating } = action.payload;
            state.products = state.products.map((product) => {
                const isFilteredOut = (maxPrice && product.price > maxPrice) ||
                    (minRating && product.averageRating < minRating);
                return { ...product, isFilteredOut };
            });
        },
    },
});

export const { getProductsStart, getProductsSuccess, getProductsFailure, setProductToEdit, addProduct, updateProduct, deleteProduct, filterProducts } = productsSlice.actions;

export default productsSlice.reducer;