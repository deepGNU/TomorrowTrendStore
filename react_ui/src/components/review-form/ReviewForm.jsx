import React from 'react'
import { postReviewAPI } from '../../api/resources/reviews'
import { editReviewAPI } from '../../api/resources/reviews'
import { useState } from 'react'
import { useSelector } from 'react-redux'

const ReviewForm = ({ productId, onSubmit, reviewToEdit = null }) => {
    const [rating, setRating] = useState(reviewToEdit?.rating ?? '')
    const [comment, setComment] = useState(reviewToEdit?.comment ?? '')
    const userId = useSelector(state => state.currentUser.id)

    const handleRatingChange = (event) => {
        setRating(event.target.value)
    }

    const handleCommentChange = (event) => {
        setComment(event.target.value)
    }

    const handleReviewSubmit = async (event) => {
        event.preventDefault()

        const reviewToSubmit = {
            id: reviewToEdit?.id ?? 0,
            userId,
            productId,
            rating,
            comment,
        }

        console.log(reviewToSubmit)

        if (reviewToEdit) {
            await editReviewAPI(reviewToSubmit)
            onSubmit({ ...reviewToEdit, ...reviewToSubmit })
        } else {
            await postReviewAPI(reviewToSubmit)
                .then(review => onSubmit(review))
        }

        setRating('')
        setComment('')
    }

    return (
        <form onSubmit={handleReviewSubmit}>
            <label htmlFor="rating">Rating: </label>
            <select
                onChange={handleRatingChange}
                value={rating ?? ''}
                required
                name="rating"
                id="rating"
            >
                <option value="" disabled hidden>Rating</option>
                <option value={5}>5 stars</option>
                <option value={4}>4 stars</option>
                <option value={3}>3 stars</option>
                <option value={2}>2 stars</option>
                <option value={1}>1 star</option>
            </select>

            <label htmlFor="comment">Leave a review: </label>
            <textarea
                onChange={handleCommentChange}
                value={comment}
                name="comment"
                id="comment"
                cols="30"
                rows="10"
            />

            <button type="submit">Submit</button>
        </form>
    )
}

export default ReviewForm