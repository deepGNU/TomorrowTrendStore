import './ProductForm.css'
import React from 'react'
import useProductForm from '../../hooks/useProductForm'
import FileInput from '../file-input/FileInput'
import BtnNeon from '../buttons/BtnNeon'
import { Blocks } from 'react-loader-spinner'
import PRODUCT_CATEGORY_IDS from '../../utils/product-category-ids'

const ProductForm = () => {
    const { isInEditMode, isFeatured, name, productCategoryId, shortDescription, longDescription, price, stock, priceInputRef, stockInputRef, imageURL, imageInputRef, imageFileToUpload, imageFileToUploadURL, handleIsFeaturedChange, handleNameChange, handleProductCategoryIdChange, handleShortDescriptionChange, handleLongDescriptionChange, handlePriceChange, handleStockChange, handleImageChange, handleImageClear, imageIsUploading, handleEditSubmit, handleCreateSubmit } = useProductForm()
    const originalName = name
    return (
        <div className='product-form-wrapper'>
            {isInEditMode ? <h1>Edit Product '{originalName}'</h1> : <h1>Create Product</h1>}

            {imageIsUploading &&
                <div className='loader'>
                    <h1>Uploading image...</h1>
                    <Blocks
                        width={200}
                        height={200}
                    />
                </div>}

            <form
                onSubmit={isInEditMode ? handleEditSubmit : handleCreateSubmit}
                className='product-form'
            >
                <div className='form-field product-form-field-photo'>
                    <FileInput
                        inputRef={imageInputRef}
                        onChange={handleImageChange}
                        onClear={handleImageClear}
                        isFileToUpload={imageFileToUpload ? true : false}
                        imageURL={imageFileToUploadURL ?? imageURL}
                    />
                </div>

                <div className='product-form-right-section'>
                    <label htmlFor="isFeatured">Is Featured</label>
                    <input onChange={handleIsFeaturedChange} type="checkbox" name="isFeatured" id="isFeatured" checked={isFeatured ?? false} />

                    <label htmlFor="name">Name</label>
                    <input onChange={handleNameChange} type="text" name="name" id="name" value={name ?? ''} required maxLength={50} />

                    <label htmlFor="productCategoryId">Product Category</label>
                    <select onChange={handleProductCategoryIdChange} name="productCategoryId" id="productCategoryId" value={productCategoryId ?? ''} required>
                        <option value=''>Select a category</option>
                        {Object.entries(PRODUCT_CATEGORY_IDS).map(([key, value]) => (
                            <option key={key} value={value}>{key}</option>
                        ))}
                    </select>

                    <label htmlFor="price">Price</label>
                    <input onChange={handlePriceChange} type="number" name="price" id="price" value={price ?? ''} required step='0.01' ref={priceInputRef} />

                    <label htmlFor="stock">Stock</label>
                    <input onChange={handleStockChange} type="number" name="stock" id="stock" value={stock ?? ''} required step="1" ref={stockInputRef} />
                </div>

                <div className='submit-btn-wrapper'>

                    <label htmlFor="short-description">Description</label>
                    <textarea onChange={handleShortDescriptionChange} name="short-description" id="short-description" value={shortDescription ?? ''} maxLength={200} required />

                    <label htmlFor="long-description">Long Description</label>
                    <textarea onChange={handleLongDescriptionChange} name="long-description" id="long-description" value={longDescription ?? ''} maxLength={5000} required />
                    <BtnNeon text={'Submit'} className='submit-btn' />
                </div>
            </form>
        </div>
    )
}

export default ProductForm