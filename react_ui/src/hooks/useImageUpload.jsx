import { useState, useRef } from "react";
import * as Bytescale from "@bytescale/sdk"

const useImageUpload = () => {
    const imageInputRef = useRef();
    const [imageFileToUpload, setFile] = useState();
    const [imageFileToUploadURL, setFileURL] = useState();
    const [imageIsUploading, setIsUploading] = useState(false);
    const apiKey = process.env.REACT_APP_BYTESCALE_API_KEY

    const handleImageChange = (e) => {
        setFile(e.target.files[0]);
        setFileURL(URL.createObjectURL(e.target.files[0]));
    }

    const handleImageClear = (e) => {
        e.preventDefault()
        imageInputRef.current.value = null
        setFile(null)
        setFileURL(null)
    }

    const uploadManager = new Bytescale.UploadManager({
        apiKey,
    });

    const handleImageUpload = async () => {
        try {
            setIsUploading(true);
            const { fileUrl, filePath } = await uploadManager.upload({
                data: imageFileToUpload,
            });
            console.log("Uploaded file to", fileUrl, filePath);
            setIsUploading(false);
            return fileUrl
        } catch (error) {
            console.error(error.message);
            alert(error.message);
            setIsUploading(false);
            return null
        }
    }

    return {
        imageInputRef,
        imageFileToUpload,
        imageFileToUploadURL,
        handleImageChange,
        handleImageClear,
        handleImageUpload,
        imageIsUploading,
    }
}

export default useImageUpload