import './Product.css'
import React from 'react'
import { useNavigate } from 'react-router-dom'
import { BsCartCheck as IsInCart } from "react-icons/bs";
import BtnAddToCart from '../buttons/BtnAddToCart'
import StarRating from '../star-rating/StarRating'

const Product = ({ product, className = '' }) => {
    const navigate = useNavigate()

    const handleViewDetailsClick = () => {
        navigate(`/products/${product.id}`)
    }

    return (
        <div
            className={`product-card neon-sign ${className}`}
            onClick={handleViewDetailsClick}
            title='View details'
        >
            <img className='product-image' src={product?.imageURL} alt="Product" />

            <h3>{product?.name}</h3>

            <p>{product?.shortDescription}</p>

            <div className="stats-div">
                <span className='product-stock'>IN STOCK: {product?.stock}</span>
                <span className='product-price'>${product?.price}</span>
                <StarRating className='product-rating' rating={product?.averageRating} numRatings={product?.numberOfRatings} />
            </div>

            {product?.isInCart ? (
                <div className='is-in-cart-icon'>
                    <IsInCart />
                </div>) : (
                <BtnAddToCart product={product} />
            )}
        </div>
    )
}

export default Product