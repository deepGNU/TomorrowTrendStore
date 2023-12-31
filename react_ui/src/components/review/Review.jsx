import './Review.css'
import React from 'react'
import { useSelector } from 'react-redux'
import BtnNeon from '../buttons/BtnNeon'
import StarRating from '../star-rating/StarRating'

const Review = ({ review, onDelete, onEdit }) => {
    const currentUserId = useSelector(state => state.currentUser?.id)
    const currentUserIsAdmin = useSelector(state => state.currentUser?.role === 'Admin')
    const canAlterReview = parseInt(currentUserId) === review?.userId || currentUserIsAdmin

    return (
        <div className='review-div'>
            <div className='review-user'>
                <img src={review?.user?.profileImageURL ?? ''} alt="Profile" />
                <span>{review?.user?.username}</span>
            </div>
            <StarRating rating={review?.rating} />
            <p>{review?.comment}</p>
            {canAlterReview &&
                <>
                    <BtnNeon text='Delete' onClick={() => onDelete(review.id)} />
                    <BtnNeon text='Edit' onClick={() => onEdit(review)} />
                </>}
        </div>
    )
}

export default Review