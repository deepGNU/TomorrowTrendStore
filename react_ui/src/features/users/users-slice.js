import { createSlice } from "@reduxjs/toolkit";
import { resetState } from "../shared-actions";

const initialState = {
    users: [],
    loading: false,
    error: null,
    userToEdit: null,
};

const usersSlice = createSlice({
    name: "users",
    initialState,
    reducers: {
        getUsersStart(state) {
            state.loading = true;
        },
        getUsersSuccess(state, action) {
            state.users = action.payload;
            state.loading = false;
            state.error = null;
        },
        getUsersFailure(state, action) {
            state.loading = false;
            state.error = action.payload;
        },
        setUserToEdit(state, action) {
            state.userToEdit = action.payload;
        },
        updateUser(state, action) {
            const updatedUser = action.payload;
            const index = state.users.findIndex((user) => user.id === updatedUser.id);
            state.users[index] = updatedUser;
            state.userToEdit = null;
        },
        deleteUser(state, action) {
            const userId = action.payload;
            state.users = state.users.filter((user) => user.id !== userId);
        },
        addUser(state, action) {
            const newUser = action.payload;
            state.users = [newUser, ...state.users];
        },
    },
    extraReducers: (builder) => {
        builder.addCase(resetState, () => initialState);
    }
});

export const { resetUsersState, getUsersStart, getUsersSuccess, getUsersFailure, setUserToEdit, updateUser, deleteUser, addUser } = usersSlice.actions;

export default usersSlice.reducer;