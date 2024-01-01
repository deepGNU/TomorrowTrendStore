import api from "../e-store-api";
import { getUsersStart, getUsersSuccess, getUsersFailure, updateUser, deleteUser } from "../../features/users/users-slice";
import Swal from "sweetalert2";
import { toast } from "react-toastify";

export const getUsersAPI = async (dispatch) => {
    try {
        dispatch(getUsersStart());
        const res = await api.get("/Users");
        dispatch(getUsersSuccess(res.data));
    } catch (error) {
        dispatch(getUsersFailure(error));
        console.error(error.message);
    }
}

export const getUserByIdAPI = async (userId) => {
    try {
        const response = await api.get(`/users/${userId}`);
        return response.data;
    } catch (error) {
        console.error(error.message);
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `${error.message}`,
            timerProgressBar: true,
            timer: 3000,
        });
    }
}

export const getLoggedInUserAPI = async (userId) => {
    try {
        const response = await api.get(`/users/${userId}/loggedin`);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const getUsersBySearchAPI = async (dispatch, searchQuery) => {
    try {
        dispatch(getUsersStart());
        const response = await api.get(`/users/search?query=${searchQuery}`);
        dispatch(getUsersSuccess(response.data));
    }
    catch (error) {
        dispatch(getUsersFailure(error));
        console.error(error.message);
    }
}

export const editUser = async (dispatch, user) => {
    try {
        const response = await api.put(`/Users/${user.id}`, { ...user });
        dispatch(updateUser(response.data));
        toast.success('User updated successfully.');
    } catch (error) {
        console.error(error.message);
    }
}

export const editUserPasswordAPI = async (userId, updatePasswordModel) => {
    try {
        await api.put(`/Users/UpdatePassword/${userId}/password`, updatePasswordModel);
        toast.success('Password updated successfully.');
    } catch (error) {
        console.error(error.message);
        toast.error(error.message);
    }
}

export const canReviewProductAPI = async (productId) => {
    try {
        const response = await api.get(`/users/canreviewproduct/${productId}`);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const deleteUserAPI = async (dispatch, userId) => {
    try {
        await api.delete(`/Users/${userId}`);
        dispatch(deleteUser(userId));
    } catch (error) {
        console.error(error.message);
    }
}