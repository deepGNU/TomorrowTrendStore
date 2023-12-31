import api from "../e-store-api";
import { getProductsStart, getProductsSuccess, getProductsFailure, addProduct, deleteProduct } from "../../features/products/products-slice";
import { updateProduct } from "../../features/products/products-slice";

export const getProductsAPI = async (dispatch) => {
    try {
        dispatch(getProductsStart());
        const response = await api.get("/Products");
        dispatch(getProductsSuccess(response.data));
    } catch (error) {
        dispatch(getProductsFailure(error));
        console.error(error.message);
    }
}

export const getFeaturedProductsAPI = async () => {
    try {
        const res = await api.get("/Products/featured");
        return res.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const getProductByIdAPI = async (productId) => {
    try {
        const response = await api.get(`/Products/${productId}`);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const getProductsByQueryAPI = async (dispatch, query) => {
    try {
        dispatch(getProductsStart());
        const response = await api.get(`/Products/Results?search_query=${query}`);
        console.log(response.data);
        dispatch(getProductsSuccess(response.data));
    } catch (error) {
        console.error(error.message);
    }
}

export const getProductsByFilterAPI = async (dispatch, maxPrice, minRating) => {
    try {
        dispatch(getProductsStart());
        const response = await api.get(
            `/Products/Filter?${maxPrice ? 'maxPrice=' + maxPrice + '&' : ''}${minRating ? 'minRating=' + minRating : ''}`
        );
        dispatch(getProductsSuccess(response.data));
    } catch (error) {
        console.error(error.message);
    }
}

export const addProductAPI = async (dispatch, product) => {
    try {
        const response = await api.post('/Products', product);
        dispatch(addProduct(response.data));
    } catch (error) {
        console.error(error.message);
    }
}

export const editProductAPI = async (dispatch, product) => {
    try {
        const response = await api.put(`/Products/${product.id}`, { ...product });
        dispatch(updateProduct(response.data));
    } catch (error) {
        console.error(error.message);
    }
}

export const deleteProductAPI = async (dispatch, productId) => {
    try {
        await api.delete(`/Products/${productId}`);
        dispatch(deleteProduct(productId));
    } catch (error) {
        console.error(error.message);
    }
}