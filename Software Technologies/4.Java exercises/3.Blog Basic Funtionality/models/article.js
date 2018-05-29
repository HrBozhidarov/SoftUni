const Sequelize = require('sequelize'); //Import!

module.exports = function (sequelize) {
    const Article = sequelize.define('Article', {
        title: {
            type: Sequelize.STRING,
            allowNull: false,
            required: true
        },
        content:{
            type: Sequelize.STRING,
            allowNull: false,
            required: true
        },
        date: {
            type:Sequelize.DATE,
            allowNull:false,
            required: true,
            defaultValue: Sequelize.NOW
        },
        image: {
            type:Sequelize.STRING
        }
    });

    Article.associate=function (models) {
        Article.belongsTo(models.User, {
            foreignKey: 'authorId',
            targetKey: 'id'
        })
    };

    return Article;
};