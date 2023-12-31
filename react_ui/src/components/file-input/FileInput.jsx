import './FileInput.css'
import React from 'react'
import BtnNeon from '../buttons/BtnNeon'

const FileInput = ({ inputRef, onChange, onClear, isFileToUpload, imageURL }) => {
    return (
        <div className='file-input-div'>
            <span>Image</span>
            <img
                src={imageURL}
                alt="Product"
                className='form-image'
            />

            <label className='file-label btn-neon-card' htmlFor="file-input">Browse for Image</label>
            <input
                className='file-input'
                ref={inputRef}
                onChange={onChange}
                type="file"
                id='file-input'
            />

            <BtnNeon
                text={'Clear Image'}
                onClick={onClear}
                disabled={!isFileToUpload}
            />
        </div>
    )
}

export default FileInput