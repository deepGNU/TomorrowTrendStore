import './Products.css'
import { useEffect } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import Product from '../../components/product/Product'
import TopSection from '../../components/top-section/TopSection'
import { getProductsAPI } from '../../api/resources/products'

const Products = () => {
    const dispatch = useDispatch()
    const products = useSelector(state => state.products.products)

    useEffect(() => {
        getProductsAPI(dispatch)
    }, [dispatch])

    return (
        <>
            <TopSection />
            <br /><br /><br />
            <div className='products-div'>
                {products.map(product => (
                    !product.isFilteredOut &&
                    <Product key={product.id} product={product} />
                ))}
            </div>
        </>
    )
}

export default Products