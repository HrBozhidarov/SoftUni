import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;

public class BookLibrary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        LinkedHashMap<String, Double> data = new LinkedHashMap<>();

        for (int i = 0; i < n; i++) {
            String[] line = scanner.nextLine().split(" ");
            Book book = new Book(
                    line[0],
                    line[1],
                    line[2],
                    LocalDate.parse(line[3], DateTimeFormatter.ofPattern("dd.MM.yyyy")),
                    line[4],
                    Double.parseDouble(line[5]));

            if (!data.containsKey(book.getAuthor())) {
                data.put(book.getAuthor(), 0.0);
            }

            Double currentPriceSum = book.getPrice() + data.get(book.getAuthor());
            data.put(book.getAuthor(), currentPriceSum);
        }

        data.entrySet()
                .stream()
                .sorted((e1, e2) -> {
                    int compareValue = e2.getValue().compareTo(e1.getValue());
                    if (compareValue == 0) {
                        return e1.getKey().compareTo(e2.getKey());
                    }
                    return compareValue;
                }).forEach(e -> System.out.printf("%s -> %.2f%n",e.getKey(),e.getValue()));
    }
}

/*
class Book {
    public Book(String title, String author, String publisher, LocalDate releaseDate, String isbn, double price) {
        this.title = title;
        this.author = author;
        this.publisher = publisher;
        this.releaseDate = releaseDate;
        this.isbn = isbn;
        this.price = price;
    }

    private String title;
    private String author;
    private String publisher;
    private LocalDate releaseDate;
    private String isbn;
    private double price;

    public String getTitle() {
        return this.title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return this.author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getPublisher() {
        return this.publisher;
    }

    public void setPublisher(String publisher) {
        this.publisher = publisher;
    }

    public LocalDate getReleaseDate() {
        return this.releaseDate;
    }

    public void setReleaseDate(LocalDate releaseDate) {
        this.releaseDate = releaseDate;
    }

    public String getIsbn() {
        return this.isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public double getPrice() {
        return this.price;
    }

    public void setPrice(double price) {
        this.price = price;
    }
}*/
