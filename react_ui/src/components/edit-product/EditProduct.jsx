import React from 'react'
import './EditProduct.css'
import { setProductToEdit } from '../../features/products/products-slice'
import { deleteProductAPI } from '../../api/resources/products'
import { RiDeleteBinLine as DeleteBin } from "react-icons/ri";
import { FaEdit as Edit } from "react-icons/fa";
import { useDispatch, useSelector } from 'react-redux'
import { useNavigate } from 'react-router-dom';

const EditProduct = ({ product }) => {
    const isAdmin = useSelector(state => state.currentUser.role === 'Admin')
    const dispatch = useDispatch()
    const navigate = useNavigate()

    const handleProductClick = () => {
        navigate(`/products/${product.id}`)
    }

    const handleEditClick = (e) => {
        e.stopPropagation()
        dispatch(setProductToEdit(product))
        navigate('/product-form')
    }

    const handleDeleteClick = (e) => {
        e.stopPropagation()
        const confirmDelete = window.confirm(`Are you sure you want to delete ${product.name}?`)
        if (!confirmDelete) return
        deleteProductAPI(dispatch, product.id)
    }

    return (
        <div
            className='edit-product-div neon-sign'
            onClick={handleProductClick}
        >
            <div>
                <h2>
                    {product.name}
                </h2>
                <img src={product.imageURL} alt="Product" />
            </div>

            {isAdmin &&
                <div className='btns-edit-product'>
                    <button className='btn-neon-card' onClick={handleEditClick}>
                        <Edit /> Edit
                    </button>

                    <button className='btn-neon-card' onClick={handleDeleteClick}>
                        <DeleteBin /> Delete
                    </button>
                </div>}
        </div>
    )
}

export default EditProduct