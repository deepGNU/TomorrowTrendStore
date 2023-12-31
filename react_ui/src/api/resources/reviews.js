import api from "../e-store-api";

export const getReviewsByProductAPI = async (productId) => {
    try {
        const response = await api.get(`/reviews/?productid=${productId}`);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const postReviewAPI = async (review) => {
    try {
        const response = await api.post('/reviews', review);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const deleteReviewAPI = async (reviewId) => {
    try {
        await api.delete(`/reviews/${reviewId}`);
    } catch (error) {
        console.error(error.message);
    }
}

export const editReviewAPI = async (review) => {
    try {
        const response = await api.put(`/reviews/${review.id}`, review);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}