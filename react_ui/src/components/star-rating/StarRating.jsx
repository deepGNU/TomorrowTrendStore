import './StarRating.css';
import React from 'react';
import { IoIosStar as FullStar, IoIosStarHalf as HalfStar, IoIosStarOutline as EmptyStar } from "react-icons/io";

const StarRating = ({ rating, numRatings = null }) => {
    const MAX_STARS = 5;
    const fullStars = Math.floor(rating);
    const hasHalfStar = rating % 1 !== 0;
    const emptyStars = MAX_STARS - fullStars - (hasHalfStar ? 1 : 0);

    const renderStars = (count, starIcon) => {
        const stars = [];
        for (let i = 0; i < count; i++) {
            stars.push(
                <span key={i}>{starIcon}</span>
            );
        }
        return stars;
    };

    if (rating === 0) { // A rating of zero is impossible, so we can assume that the product has not been rated yet
        return null;
    }

    return (
        <div className="star-rating">
            {renderStars(fullStars, <FullStar />)}
            {hasHalfStar && <span><HalfStar /></span>}
            {renderStars(emptyStars, <EmptyStar />)}
            {numRatings &&
                <span className='num-ratings'>({numRatings + (numRatings === 1 ? ' rating' : ' ratings')})</span>
            }
        </div>
    );
};

export default StarRating;