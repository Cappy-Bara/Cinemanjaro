import { useEffect, useRef, useState, useCallback } from "react";
import { Grid, Header, Loader } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { AllMoviesListElementData } from "../../app/models/Movie";
import AllMoviesItem from "./AllMovieListItem";

const PAGE_SIZE = 20;

const AllMovies = () => {
    const [movies, setMovies] = useState<AllMoviesListElementData[]>([]);
    const [page, setPage] = useState(1);
    const [hasMore, setHasMore] = useState(true);
    const [loading, setLoading] = useState(false);

    const loaderRef = useRef<HTMLDivElement | null>(null);

    const loadMovies = useCallback(async () => {
        if (loading || !hasMore) return;

        setLoading(true);

        try {
            const result = await agent.Movies.all(page, PAGE_SIZE);

            setMovies(prev => [...prev, ...result.movies]);

            if (result.movies.length < PAGE_SIZE) {
                setHasMore(false);
            } else {
                setPage(prev => prev + 1);
            }
        } catch (error) {
            console.error(error);
        } finally {
            setLoading(false);
        }
    }, [page, loading, hasMore]);

    // Initial load
    useEffect(() => {
        loadMovies();
    }, []);

    // Intersection observer
    useEffect(() => {
        if (!loaderRef.current) return;

        const observer = new IntersectionObserver(
            ([entry]) => {
                if (entry.isIntersecting) {
                    loadMovies();
                }
            },
            {
                root: null,
                rootMargin: "200px", // 🔥 preload before reaching bottom
                threshold: 0,
            }
        );

        observer.observe(loaderRef.current);

        return () => observer.disconnect();
    }, [loadMovies]);

    return (
        <Grid>
            <Grid.Column width={16}>
                <Header as="h1" dividing textAlign="center">
                    All Movies
                </Header>
            </Grid.Column>

            <Grid.Column width={16}>
                <AllMoviesItem movies={movies} />
            </Grid.Column>

            {hasMore && (
                <Grid.Column width={16} textAlign="center">
                    <div ref={loaderRef} style={{ height: 40 }}>
                        {loading && <Loader active inline />}
                    </div>
                </Grid.Column>
            )}
        </Grid>
    );
};

export default AllMovies;
