function result(vote) {
    switch (vote) {
        case 'upvote':
            this.upvotes++;
            break;
        case 'downvote':
            this.downvotes++;
            break;
        case 'score':
            let votes = sorce(this);
            let status = getStatus(this);

            return [votes[0], votes[1], votes[0] - votes[1], status];
    }

    function getStatus(source) {
        let upvotes = source.upvotes;
        let downvotes = source.downvotes;
        let totalVotes = upvotes + downvotes;

        if(totalVotes < 10) {
            return 'new';
        }
        else if (totalVotes * 0.66 < upvotes) {
            return 'hot';
        }
        else if (upvotes - downvotes >= 0 && totalVotes > 100) {
            return 'controversial';
        }
        else if (upvotes - downvotes < 0) {
            return 'unpopular';
        }

        return 'new';
    }

    function sorce(obj) {
        let upvotes = obj.upvotes;
        let downvotes = obj.downvotes;

        if (upvotes + downvotes > 50) {
            let add25PercentFromBiggerVotes = Math.ceil(Math.max(upvotes, downvotes) * 0.25);

            upvotes += add25PercentFromBiggerVotes;
            downvotes += add25PercentFromBiggerVotes;
        }

        return [upvotes, downvotes];
    }
}