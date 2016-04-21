package ru.istu.survey.dto;

import ru.istu.survey.entity.Question;
import ru.istu.survey.entity.User;

import java.util.List;

public class SurveyDTO {

    private String id;

    private boolean isPublic;

    private boolean isAnonymous;

    private String state;

    private User author;

    private String title;

    private String description;

    private List<Question> question;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public boolean isPublic() {
        return isPublic;
    }

    public void setPublic(boolean aPublic) {
        isPublic = aPublic;
    }

    public boolean isAnonymous() {
        return isAnonymous;
    }

    public void setAnonymous(boolean anonymous) {
        isAnonymous = anonymous;
    }

    public String getState() {
        return state;
    }

    public void setState(String state) {
        this.state = state;
    }

    public User getAuthor() {
        return author;
    }

    public void setAuthor(User author) {
        this.author = author;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public List<Question> getQuestion() {
        return question;
    }

    public void setQuestion(List<Question> question) {
        this.question = question;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        SurveyDTO dto = (SurveyDTO) o;

        if (isPublic != dto.isPublic) return false;
        if (isAnonymous != dto.isAnonymous) return false;
        if (id != null ? !id.equals(dto.id) : dto.id != null) return false;
        if (state != null ? !state.equals(dto.state) : dto.state != null) return false;
        if (author != null ? !author.equals(dto.author) : dto.author != null) return false;
        if (title != null ? !title.equals(dto.title) : dto.title != null) return false;
        if (description != null ? !description.equals(dto.description) : dto.description != null) return false;
        return question != null ? question.equals(dto.question) : dto.question == null;

    }

    @Override
    public int hashCode() {
        int result = id != null ? id.hashCode() : 0;
        result = 31 * result + (isPublic ? 1 : 0);
        result = 31 * result + (isAnonymous ? 1 : 0);
        result = 31 * result + (state != null ? state.hashCode() : 0);
        result = 31 * result + (author != null ? author.hashCode() : 0);
        result = 31 * result + (title != null ? title.hashCode() : 0);
        result = 31 * result + (description != null ? description.hashCode() : 0);
        result = 31 * result + (question != null ? question.hashCode() : 0);
        return result;
    }
}
