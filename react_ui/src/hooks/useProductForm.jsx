import { useSelector, useDispatch } from "react-redux"
import { useState, useRef } from "react"
import useImageUpload from "./useImageUpload"
import { editProductAPI } from "../api/resources/products"
import { useNavigate } from "react-router-dom"
import { addProductAPI } from "../api/resources/products"
import Swal from "sweetalert2"

const useProductForm = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const priceInputRef = useRef();
    const stockInputRef = useRef();
    const { imageInputRef, imageFileToUpload, imageFileToUploadURL, handleImageChange, handleImageClear, handleImageUpload, imageIsUploading } = useImageUpload()
    const productToEdit = useSelector(state => state.products.productToEdit)
    const [name, setName] = useState(productToEdit?.name)
    const [productCategoryId, setProductCategoryId] = useState(productToEdit?.productCategoryId)
    const [shortDescription, setShortDescription] = useState(productToEdit?.shortDescription)
    const [price, setPrice] = useState(productToEdit?.price)
    const [stock, setStock] = useState(productToEdit?.stock)
    const [isFeatured, setIsFeatured] = useState(productToEdit?.isFeatured)
    const [longDescription, setLongDescription] = useState(productToEdit?.longDescription)

    const handleNameChange = (event) => {
        setName(event.target.value)
    }

    const handleProductCategoryIdChange = (event) => {
        setProductCategoryId(event.target.value)
    }

    const handleShortDescriptionChange = (event) => {
        setShortDescription(event.target.value)
    }

    const handleLongDescriptionChange = (event) => {
        setLongDescription(event.target.value)
    }

    const handlePriceChange = (event) => {
        setPrice(event.target.value)
    }

    const handleStockChange = (event) => {
        setStock(event.target.value)
    }

    const handleIsFeaturedChange = (event) => {
        setIsFeatured(event.target.checked)
    }

    const getUpdatedProduct = () => {
        return {
            ...productToEdit,
            isFeatured,
            name,
            productCategoryId,
            shortDescription,
            longDescription,
            price,
            stock,
            imageURL: productToEdit?.imageURL
        }
    }

    const handleCreateSubmit = async (event) => {
        event.preventDefault()

        if (!/^\d+(\.\d{0,2})?$/.test(priceInputRef.current.value)) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter a valid price, up to 2 decimal places!',
            })
            return;
        }

        if (!/^\d+$/.test(stockInputRef.current.value)) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter a valid integer for the stock number!',
            })
            return;
        }

        if (!imageFileToUpload) {
            addProductAPI(dispatch, getUpdatedProduct())
            navigate(-1)
            return
        }

        const uploadedImageURL = await handleImageUpload()

        if (!uploadedImageURL) {
            await Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'There was an error uploading the image. Do you want to continue without uploading the image?',
                showCancelButton: true,
                confirmButtonText: 'Continue Anyway',
            }).then((result) => {
                if (!result.isConfirmed) return
                addProductAPI(dispatch, getUpdatedProduct())
                navigate(-1)
            })
            return
        }

        dispatch(addProductAPI({ ...getUpdatedProduct(), imageURL: uploadedImageURL }))
        navigate(-1)
    }

    const handleEditSubmit = async (event) => {
        event.preventDefault()

        if (!/^\d+(\.\d{0,2})?$/.test(priceInputRef.current.value)) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter a valid price, up to 2 decimal places!',
            })
            return;
        }

        if (!/^\d+$/.test(stockInputRef.current.value)) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter a valid integer for the stock number!',
            })
            return;
        }

        if (!imageFileToUpload) {
            await editProductAPI(dispatch, getUpdatedProduct())
            navigate(-1)
            return
        }

        const uploadedImageURL = await handleImageUpload()

        if (!uploadedImageURL) {
            await Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'There was an error uploading the image. Do you want to continue without uploading the image?',
                showCancelButton: true,
                confirmButtonText: 'Continue Anyway',
            }).then((result) => {
                if (!result.isConfirmed) return
                editProductAPI(dispatch, getUpdatedProduct())
                navigate(-1)
            })
            return
        }

        await editProductAPI(dispatch, { ...getUpdatedProduct(), imageURL: uploadedImageURL })
        alert('you should not be here, updating product')

        navigate(-1)
    }

    return {
        isInEditMode: !!productToEdit,
        isFeatured,
        name,
        productCategoryId,
        shortDescription,
        longDescription,
        price,
        stock,
        priceInputRef,
        stockInputRef,
        imageURL: productToEdit?.imageURL,
        imageInputRef,
        imageFileToUpload,
        imageFileToUploadURL,
        handleIsFeaturedChange,
        handleNameChange,
        handleProductCategoryIdChange,
        handleShortDescriptionChange,
        handleLongDescriptionChange,
        handlePriceChange,
        handleStockChange,
        handleImageChange,
        handleImageClear,
        imageIsUploading,
        getUpdatedProduct,
        handleEditSubmit,
        handleCreateSubmit
    }
}

export default useProductForm