module.exports = {
    devServer: {
        proxy: {
            '/api': {
                target: 'https://staff-manager-lx.azurewebsites.net',
                changeOrigin: true,
				pathRewrite: {
					'^/api': ''
				}
            }
        }
    }
};