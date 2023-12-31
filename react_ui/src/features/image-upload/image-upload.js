import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    image: null,
    imageURL: null,
};

const imageUploadSlice = createSlice({
    name: "imageUpload",
    initialState,
    reducers: {
        setImage(state, action) {
            console.log('setImage action.payload:', action.payload);
            state.image = action.payload;
        },
        setImageURL(state, action) {
            console.log('setImageURL action.payload:', action.payload);
            state.imageURL = action.payload;
        },
    },
});

export const { setImage, setImageURL } = imageUploadSlice.actions;

export default imageUploadSlice.reducer;
