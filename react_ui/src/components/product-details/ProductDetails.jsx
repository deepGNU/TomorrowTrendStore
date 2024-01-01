import './ProductDetails.css'
import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { getProductByIdAPI } from '../../api/resources/products'
import { getReviewsByProductAPI } from '../../api/resources/reviews'
import ReviewForm from '../review-form/ReviewForm'
import { canReviewProductAPI } from '../../api/resources/users'
import { deleteReviewAPI } from '../../api/resources/reviews'
import BtnAddToCart from '../buttons/BtnAddToCart'
import StarRating from '../star-rating/StarRating'
import Review from '../review/Review'
import { useSelector } from 'react-redux'

const ProductDetails = () => {
    const isLoggedIn = useSelector(state => state.currentUser.isLoggedIn)
    const { productId } = useParams()
    const [product, setProduct] = useState()
    const [reviews, setReviews] = useState([])
    const [canReview, setCanReview] = useState(false)
    const [reviewToEdit, setReviewToEdit] = useState(null)

    const updatePage = () => {
        getProductByIdAPI(productId)
            .then(product => setProduct(product))
        getReviewsByProductAPI(productId)
            .then(reviews => setReviews(reviews))
        if (!isLoggedIn) return
        canReviewProductAPI(productId)
            .then(canReview => setCanReview(canReview))
    }

    useEffect(() => {
        updatePage()
    }, [productId])

    const handleReviewAdded = (review) => {
        updatePage()
    }

    const handleDeleteReview = (reviewId) => {
        const confirmDelete = window.confirm('Are you sure you want to delete this review?')
        if (!confirmDelete) return
        deleteReviewAPI(reviewId)
            .then(() => {
                updatePage()
            })
    }

    const handleReviewEdited = (review) => {
        setReviewToEdit(null)
        updatePage()
    }

    return (
        <div className='product-details-div'>
            <img className='img-product-details' src={product?.imageURL} alt={product?.name} />
            <div className='right-col'>
                <h1>{product?.name}</h1>
                <p>{product?.shortDescription}</p>
                <p>{product?.longDescription}</p>

                <div className='stats-div'>
                    <p className='product-stock'>IN STOCK: {product?.stock}</p>
                    <p className='product-price'>${product?.price}</p>
                    <StarRating rating={product?.averageRating} numRatings={product?.numberOfRatings} />
                </div>
                <BtnAddToCart product={product} />
            </div>

            <div className="bottom-row">
                <hr />
                {
                    (reviewToEdit) &&
                    <ReviewForm
                        productId={productId}
                        onSubmit={handleReviewEdited}
                        reviewToEdit={reviewToEdit}
                    />
                }
                {
                    (!reviewToEdit && canReview) &&
                    <ReviewForm
                        productId={productId}
                        onSubmit={handleReviewAdded}
                    />
                }

                {reviews?.length > 0 &&
                    <>
                        <h2>Reviews</h2>
                        {reviews?.map(review => (
                            <Review
                                key={review?.id}
                                review={review}
                                onDelete={handleDeleteReview}
                                onEdit={setReviewToEdit}
                            />
                        ))}
                    </>
                }
            </div>
        </div >
    )
}

export default ProductDetails