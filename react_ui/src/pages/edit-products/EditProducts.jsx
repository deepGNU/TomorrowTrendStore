import './EditProducts.css'
import React from 'react'
import { useSelector, useDispatch } from 'react-redux'
import EditProduct from '../../components/edit-product/EditProduct'
import { useNavigate } from 'react-router-dom'
import { useEffect } from 'react'
import { getProductsAPI } from '../../api/resources/products'
import BtnNeon from '../../components/buttons/BtnNeon'

const EditProducts = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const products = useSelector(state => state.products.products)

    useEffect(() => {
        getProductsAPI(dispatch)
    }, [dispatch])

    const handleAddProductClick = () => {
        navigate('/product-form')
    }

    return (
        <>
            <div className="top-section">
                <h1>Manage Products</h1>
                <BtnNeon text={'Add Product'} onClick={handleAddProductClick} />
            </div>
            <div className='edit-products-page'>
                {products.map(product => (
                    <EditProduct key={product.id} product={product} />
                ))}
            </div>
        </>
    )
}

export default EditProducts