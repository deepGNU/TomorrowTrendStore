import { useState, useRef } from "react";
import * as Bytescale from "@bytescale/sdk"

const useImageUpload = () => {
    const imageInputRef = useRef();
    const [imageFileToUpload, setFile] = useState();
    const [imageFileToUploadURL, setFileURL] = useState();
    const [imageIsUploading, setIsUploading] = useState(false);
    const apiKey = process.env.REACT_APP_BYTESCALE_API_KEY
    let uploadManager;
    if (apiKey) uploadManager = new Bytescale.UploadManager({ apiKey });

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

    const handleImageUpload = async () => {
        try {
            if (!apiKey) throw new Error("Missing API key");
            setIsUploading(true);
            const { fileUrl } = await uploadManager.upload({
                data: imageFileToUpload,
            });
            setIsUploading(false);
            return fileUrl
        } catch (error) {
            console.error(error.message);
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