import React from 'react'
import './Buttons.css'
import { addToCart } from '../../api/resources/carts'
import { useDispatch } from 'react-redux'
import { FaShoppingCart as Add2Cart } from "react-icons/fa";

const BtnAddToCart = ({ product }) => {
    const dispatch = useDispatch()

    const handleAddToCart = (e) => {
        e.stopPropagation()
        addToCart(dispatch, product)
    }

    return (
        <div>
            <button
                className='btn-neon-card notice-me btn-add-to-cart'
                onClick={handleAddToCart}
                title='Add to cart'
            >
                <Add2Cart /> Add to Cart
            </button>
        </div>
    )
}

export default BtnAddToCart