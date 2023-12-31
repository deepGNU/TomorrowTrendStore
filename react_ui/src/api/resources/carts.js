import api from '../e-store-api';
import { getCartStart, getCartSuccess, getCartFailure, updateLoggedInUserCart, deleteOrderLine, updateOrderLine, clearCart } from '../../features/carts/carts-slice';
import { updateProduct } from '../../features/products/products-slice';
import { toast } from 'react-toastify';
import Swal from 'sweetalert2';

export const fetchCarts = async () => {
    try {
        const response = await api.get('/carts');
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
};

export const fetchCart = async (dispatch) => {
    try {
        dispatch(getCartStart());
        const response = await api.get('/carts');
        dispatch(getCartSuccess(response.data));
    } catch (error) {
        console.error(error.message);
        dispatch(getCartFailure(error));
    }
}

export const addToCart = async (dispatch, product) => {
    try {
        const response = await api.post('/carts/orderlines', product.id);
        dispatch(updateLoggedInUserCart(response.data));
        dispatch(updateProduct({ ...product, isInCart: true }));
        Swal.fire({
            title: `${product.name} added to cart!`,
            icon: 'success',
            confirmButtonText: 'Cool',
            timer: 5000,
            timerProgressBar: true,
            html: `
            <button class='btn-neon-card notice-me'>
                <a href='/cart'>Go to cart</a>
            </button>`,
        })
    } catch (error) {
        console.error(error.message);
    }
}

export const removeFromCart = async (dispatch, cartId, orderLineId) => {
    try {
        await api.delete(`/carts/${cartId}/orderlines/${orderLineId}`);
        dispatch(deleteOrderLine(orderLineId));
        toast.success('Product removed from cart.');
    } catch (error) {
        console.error(error.message);
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error.message,
            timer: 3000,
            timerProgressBar: true,
        })
    }
}

export const updateOrderLineAPI = async (dispatch, cartId, orderLineId, quantity) => {
    try {
        const response = await api.put(`/carts/${cartId}/orderlines/${orderLineId}`, quantity);
        dispatch(updateOrderLine(response.data));
        toast.success('Cart updated successfully.');
    } catch (error) {
        console.error(error.message);
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error.message,
            timer: 3000,
            timerProgressBar: true,
        })
    }
}

export const checkoutAPI = async (dispatch, cartId) => {
    try {
        await api.put(`/carts/${cartId}/checkout`);
        dispatch(clearCart());
        Swal.fire({
            icon: 'success',
            title: 'Checkout Success',
            text: `Thank you for shopping with us!`,
            timer: 3000,
            timerProgressBar: true,
        })
    } catch (error) {
        console.error(error.message);
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error.message,
            timer: 3000,
            timerProgressBar: true,
        })
    }
}