import './Home.css'
import { useEffect, useState } from 'react'
import tomorrowtrendWelcome from '../../images/tomorrowtrend-welcome.png'
import RotatingList from '../../components/rotating-list/RotatingList'
import { getFeaturedProductsAPI } from '../../api/resources/products'
import { useNavigate } from 'react-router-dom'

const Home = () => {
    const navigate = useNavigate()
    const [products, setProducts] = useState([])

    useEffect(() => {
        const fetchProducts = async () => {
            const data = await getFeaturedProductsAPI()
            setProducts(data)
        }
        fetchProducts()
    }, [])

    return (
        <div className='home-page'>
            <section id="intro">
                <h1>Welcome to TomorrowTrend Electronics!</h1>
                <p>Your one-stop shop for the latest and greatest in futuristic electronics. Explore our wide range of cutting-edge gadgets!</p>
            </section>

            <img className='img-welcome' src={tomorrowtrendWelcome} alt="welcome-sign" />

            <section id="products">
                <h2>Featured Products</h2>
                <button
                    title='View all products'
                    className='neon-sign'
                    onClick={() => navigate('/products')}
                >All Products</button>
                {products?.length > 0 && <RotatingList items={products} />}
            </section>
        </div>
    )
}

export default Home